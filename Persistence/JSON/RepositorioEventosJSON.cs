using Domain;
using Domain.Evento;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

namespace Persistence.JSON
{
    public class RepositorioEventosJSON : IRepositorioEventos

    {
        private String path = @"..\CoreAMTest\repos\eventos.json";

        public RepositorioEventosJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\eventos.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\eventos.json";
            }
        }

        public Evento Agregar(Evento evento)
        {
            List<Evento> eventos = leerEventos();

            Evento eventoValido = eventos.Find((c) =>
            {
                return c.Id == evento.Id || (c.Nombre.ToUpper().Equals(evento.Nombre.ToUpper())
                && c.Fecha == evento.Fecha && c.Ciudad.ToUpper().Equals(evento.Ciudad.ToUpper()));
            });

            if (eventoValido != null)
            {
                throw new EventoYaExisteException("Ya existe un evento con ese nombre en este evento");
            }

          
            evento.Id = (eventos.Count > 0) ? eventos[eventos.Count - 1].Id + 1 : 1;
            eventos.Add(evento);

            guardarEventos(eventos);

            return evento;
        }

        public Evento Editar(Evento eventoNew)
        {
            List<Evento> eventos = leerEventos();
            Evento eventoOld = eventos.Find(e => e.Id == eventoNew.Id);
            Evento eventoValido = eventos.Find((e) =>
            {
                return e.Id == eventoNew.Id && e.Nombre.ToUpper().Equals(eventoNew.Nombre.ToUpper()) && e.Id != eventoNew.Id;
            });

            if (eventoValido != null)
            {
                throw new EventoYaExisteException("Ya existe un evento con ese nombre");
            }

            if (eventoOld == null)
            {
                throw new EventoNoEncontradoException("El evento con el id: "+eventoNew.Id+" no fue encontrada.");
            }
            eventoOld.Id = (eventoNew.Id != 0) ? eventoNew.Id : eventoOld.Id;
            eventoOld.Fecha = (eventoNew.Fecha != null) ? eventoNew.Fecha : eventoOld.Fecha;
            eventoOld.MinimoAsistentes = (eventoNew.MinimoAsistentes != 0) ? eventoNew.MinimoAsistentes : eventoOld.MinimoAsistentes;
            eventoOld.MaximoAsistentes = (eventoNew.MaximoAsistentes != 0) ? eventoNew.MaximoAsistentes : eventoOld.MaximoAsistentes;
            eventoOld.Lugar = (eventoNew.Lugar != "") ? eventoNew.Lugar : eventoOld.Lugar;
            eventoOld.Ciudad = (eventoNew.Ciudad != "") ? eventoNew.Ciudad : eventoOld.Ciudad;
            eventoOld.Valor = (eventoNew.Valor != 0) ? eventoNew.Valor : eventoOld.Valor;
            eventoOld.Descripcion = (eventoNew.Descripcion != "") ? eventoNew.Descripcion : eventoOld.Descripcion;
            eventoOld.Nombre = (eventoNew.Nombre != "") ? eventoNew.Nombre : eventoOld.Nombre;
            guardarEventos(eventos);
            return eventoOld;
        }

        public bool Eliminar(int eventoid)
        {
            List<Evento> eventos = leerEventos();
            Evento evento = eventos.Find(c => c.Id == eventoid);

            if (evento == null)
            {
                throw new EventoNoEncontradoException("El evento con el id: "+eventoid+" no fue encontrado.");
            }

            if (eventos.Remove(evento))
            {
                return guardarEventos(eventos);                
            }
            else
            {
                throw new EventoException("No se logró eliminar el evento del repositorio de datos.");
            }
        }

        public Evento GetEvento(int eventoId)
        {
            List<Evento> eventos = leerEventos();
            Evento evento = eventos.Find(e => e.Id == eventoId);
            if (evento == null)
            {
                throw new EventoNoEncontradoException("El evento con el id: " + eventoId + " no fue encontrada.");
            }
            return evento;
        }

        public List<Evento> GetEventos()
        {
            return leerEventos();
        }

        private List<Evento> leerEventos()
        {
            try
            {
                string json = File.ReadAllText(path);
                return System.Text.Json.JsonSerializer.Deserialize<List<Evento>>(json);
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new EventoException("Ocurrió un porblema al acceder al repositorio de eventos.");
            }
        }

        private bool guardarEventos(List<Evento> eventos)
        {
            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(eventos,
                                   Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
                return true;
            }
            catch (Exception)
            {
                throw new EventoException("Ocurrió un error al guardar la información en el repositorio de datos");
            }
        }

    }
}
