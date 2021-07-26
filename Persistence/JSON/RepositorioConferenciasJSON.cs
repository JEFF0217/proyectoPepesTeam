
using Domain.Conferencia;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Persistence.JSON
{
    public class RepositorioConferenciasJSON : IRepositorioConferencias
    {

        private String path = @"..\CoreAMTest\repos\conferencias.json";

        public RepositorioConferenciasJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\conferencias.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\conferencias.json";
            }
        }

        private List<Conferencia> leerConferencias()
        {
            List<Conferencia> conferencias;
            String jsonString = "";
            try
            {
                jsonString = File.ReadAllText(path);
                conferencias = System.Text.Json.JsonSerializer.Deserialize<List<Conferencia>>(jsonString);
                return conferencias;
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de conferencias.");
            }
        }

        private void guardarConferencias(List<Conferencia> conferencias)
        {
            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(conferencias,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un problema al guardar la conferencia en el repositorio.");
            }
        }

        public List<Conferencia> GetConferencias(int EventoId, string queryNombre = "")
        {
            List<Conferencia> conferencias = leerConferencias();
            try
            {
                conferencias = conferencias
                    .FindAll(c =>
                    {
                        return c.EventoId == EventoId && c.Nombre.ToUpper()
                     .Equals(queryNombre.ToUpper());
                    });

                return conferencias;
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de conferencias.");
            }
        }

        public bool Eliminar(int id)
        {
            List<Conferencia> conferencias = leerConferencias();
            Conferencia conferencia;
            conferencia = conferencias.Find(c => c.Id == id);

            if (conferencia == null)
            {
                throw new ConferenciaNoEncontradaException($"La conferencia con el {id} no fue encontrada.");
            }

            if (conferencias.Remove(conferencia))
            {
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(conferencias, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);
                return true;
            }
            else
            {
                throw new Exception("No se logró eliminar la conferencia del repositorio de datos.");
            }
        }

        public Conferencia Agregar(Conferencia conferencia)
        {
            List<Conferencia> conferencias = leerConferencias();

            Conferencia conferenciaValidar = conferencias.Find((c) =>
            {
                return c.EventoId == conferencia.EventoId && c.Nombre.ToUpper().Contains(conferencia.Nombre.ToUpper());
            });

            if(conferenciaValidar != null)
            {
                throw new ConferenciaDuplicadaException("Ya existe una conferencia con ese nombre en este evento");
            }

            int id = 1;
            if (conferencias.Count > 0)
            {
                Conferencia aux = conferencias[conferencias.Count - 1];
                id = aux.Id + 1;
            }

            conferencia.Id = id;
            conferencias.Add(conferencia);
            this.guardarConferencias(conferencias);

            return conferencia;
        }

        public Conferencia Editar(Conferencia conferenciaNew)
        {
            List<Conferencia> conferencias = leerConferencias();
            Conferencia conferenciaOld;

            try
            {
                conferenciaOld = conferencias.Find(c => c.Id == conferenciaNew.Id);

                Conferencia conferenciaValidar = conferencias.Find((c) =>
                {
                    return c.EventoId == conferenciaNew.EventoId && c.Nombre.ToUpper().Equals(conferenciaNew.Nombre.ToUpper()) && c.Id != conferenciaNew.Id;
                });

                if (conferenciaValidar != null)
                {
                    throw new ConferenciaDuplicadaException("Ya existe una conferencia con ese nombre en este evento");
                }

                if (conferenciaOld == null)
                {
                    throw new ConferenciaNoEncontradaException($"La conferencia con el {conferenciaNew.Id} no fue encontrada.");
                }

                conferenciaOld.EventoId = (conferenciaNew.EventoId != 0) ? conferenciaNew.EventoId : conferenciaOld.EventoId;
                conferenciaOld.AulaId = (!conferenciaNew.AulaId.Equals("")) ? conferenciaNew.AulaId : conferenciaOld.AulaId;
                conferenciaOld.ConferencistaId = (conferenciaNew.ConferencistaId != 0) ? conferenciaNew.ConferencistaId : conferenciaOld.ConferencistaId;
                conferenciaOld.RecursosId = (conferenciaNew.RecursosId != null) ? conferenciaNew.RecursosId : conferenciaOld.RecursosId;
                conferenciaOld.Nombre = (!conferenciaNew.Nombre.Equals("")) ? conferenciaNew.Nombre : conferenciaOld.Nombre;
                conferenciaOld.Descripcion = (!conferenciaNew.Descripcion.Equals("")) ? conferenciaNew.Descripcion : conferenciaOld.Descripcion;
                conferenciaOld.HoraInicio = (conferenciaNew.HoraInicio != null) ? conferenciaNew.HoraInicio : conferenciaOld.HoraInicio;
                conferenciaOld.Duracion = (conferenciaNew.Duracion != 0) ? conferenciaNew.Duracion : conferenciaOld.Duracion;
                conferenciaOld.Archivo = (!conferenciaNew.Archivo.Equals("")) ? conferenciaNew.Archivo : conferenciaOld.Archivo;
            }
            catch (Exception)
            {

                throw new Exception("Ocurrio un problema en el repositorio de datos al editar la conferencia.");
            }

            

            guardarConferencias(conferencias);

            return conferenciaOld;
        }

        public Conferencia SetUrlConferencia(string url, int id)
        {
            List<Conferencia> conferencias = leerConferencias();
            Conferencia conferencia;
            conferencia = conferencias.Find(c => c.Id == id);

            if (conferencia == null)
            {
                throw new ConferenciaNoEncontradaException($"La conferencia con el {id} no fue encontrada.");
            }
            else
            {
                conferencia.Url = url;
                guardarConferencias(conferencias);
            }
            return conferencia;
        }

        public Conferencia GetConferencia(int id)
        {
            List<Conferencia> conferencias = leerConferencias();
            Conferencia conferencia = conferencias.Find(c => c.Id == id);
            if (conferencia == null)
            {
                throw new ConferenciaNoEncontradaException($"La conferencia con el {id} no fue encontrada.");
            }
            else
            {
                return conferencia;
            }
        }
    }

}