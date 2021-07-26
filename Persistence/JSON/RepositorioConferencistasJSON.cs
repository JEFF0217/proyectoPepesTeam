using Domain.Conferencista;
using Domain.Usuario;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.Json;

namespace Persistence.JSON
{
    public class RepositorioConferencistasJSON : IRepositorioConferencistas
    {

        private String path = @"..\CoreAMTest\repos\conferencistas.json";

        public RepositorioConferencistasJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\conferencistas.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\conferencistas.json";
            }
        }

        private List<Conferencista> leerConferencistas()
        {
            List<Conferencista> conferencistas;
            String jsonString = "";
            try
            {
                jsonString = File.ReadAllText(path);
                conferencistas = System.Text.Json.JsonSerializer.Deserialize<List<Conferencista>>(jsonString);

                foreach (Conferencista a in conferencistas)
                {
                    IRepositorioUsuario repo = Persistence.Factory.FabricaRepositorioUsuarios.CrearRepositorioUsuarios();
                    Usuario aux = repo.GetUsuario(a.IdUsuario);
                    a.setUsuario(aux);
                }

                return conferencistas;
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de conferencistas.");
            }
        }

        private void GuardarConferencistas(List<Conferencista> conferencistas)
        {
            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(conferencistas,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un problema al guardar el conferencista en el repositorio.");
            }
        }

        public List<Conferencista> GetConferencistas(int ConferenciaId, string queryNombre = "")
        {
            List<Conferencista> conferencistas = leerConferencistas();
            try
            {
                conferencistas = conferencistas
                    .FindAll(c =>
                    {
                        return c.ConferenciaId == ConferenciaId && c.Nombre.ToUpper()
                     .Contains(queryNombre.ToUpper());
                    });

                return conferencistas;
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de conferencistas.");
            }
        }

        public Conferencista Agregar(Conferencista Conferencista)
        {
            List<Conferencista> conferencistas = leerConferencistas();

            Conferencista conferencistaValidar = conferencistas.Find((c) =>
            {
                return c.ConferenciaId == Conferencista.ConferenciaId && c.Nombre.ToUpper().Contains(Conferencista.Nombre.ToUpper());
            });

            if (conferencistaValidar != null)
            {
                throw new ConferencistaDuplicadoException("Ya existe un conferencista con ese nombre en esta conferencia");
            }

            int id = 1;
            if (conferencistas.Count > 0)
            {
                Conferencista aux = conferencistas[conferencistas.Count - 1];
                id = aux.Id + 1;
            }

            Conferencista.Id = id;
            conferencistas.Add(Conferencista);
            this.GuardarConferencistas(conferencistas);

            return Conferencista;
        }

        public Conferencista Editar(Conferencista ConferencistaNew)
        {
            List<Conferencista> conferencistas = leerConferencistas();
            Conferencista conferencistaOld;
            try
            {
                conferencistaOld = conferencistas.Find(c => c.IdUsuario == ConferencistaNew.Id);

                Conferencista conferencistaValidar = conferencistas.Find((c) =>
                {
                    return c.ConferenciaId == ConferencistaNew.ConferenciaId && c.Nombre.ToUpper().Contains(ConferencistaNew.Nombre.ToUpper()) && c.IdUsuario != ConferencistaNew.Id;
                });
                if (conferencistaValidar != null)
                {
                    throw new ConferencistaDuplicadoException("Ya existe un conferencista con ese nombre en esta conferencia");
                }

                if (conferencistaOld == null)
                {
                    throw new ConferencistaNoEncontradoException($"el conferencista con el {ConferencistaNew.Id} no fue encontrada.");
                }

                conferencistaOld.NivelAcademico = (ConferencistaNew.NivelAcademico != "") ? ConferencistaNew.NivelAcademico : conferencistaOld.NivelAcademico;
                conferencistaOld.ConferenciaId = (ConferencistaNew.ConferenciaId != 0) ? ConferencistaNew.ConferenciaId : conferencistaOld.ConferenciaId;
                conferencistaOld.Nombre = (ConferencistaNew.Nombre != "") ? ConferencistaNew.Nombre : conferencistaOld.Nombre;
                conferencistaOld.Apellido = (ConferencistaNew.Apellido != "") ? ConferencistaNew.Apellido : conferencistaOld.Apellido;
                conferencistaOld.Correo = (ConferencistaNew.Correo != "") ? ConferencistaNew.Correo : conferencistaOld.Correo;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un error al actualizar la información en el repositorio.");
            }

            GuardarConferencistas(conferencistas);
            return conferencistaOld;
        }

        public Conferencista Eliminar(int Id)
        {
            List<Conferencista> conferencistas = leerConferencistas();
            Conferencista conferencista;
            conferencista = conferencistas.Find(c => c.Id == Id);

            if (conferencista == null)
            {
                throw new ConferencistaNoEncontradoException($"La conferencia con el {Id} no fue encontrada.");
            }

            if (conferencistas.Remove(conferencista))
            {
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(conferencistas, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);
                return conferencista;
            }
            else
            {
                throw new Exception("No se logró eliminar la conferencia del repositorio de datos.");
            }
        }

        public Conferencista GetConferencista(int Id)
        {
            List<Conferencista> conferencistas = leerConferencistas();
            Conferencista conferencista = conferencistas.Find(c => c.Id == Id);
            if (conferencista == null)
            {
                throw new ConferencistaNoEncontradoException($"La conferencia con el {Id} no fue encontrada.");
            }
            else
            {
                return conferencista;
            }
        }





    }
}
