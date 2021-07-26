using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;
using Domain.Asistente;
using Domain.Usuario;

namespace Persistence.JSON
{
    class RepositorioAsistentesJSON : IRepositorioAsistente
    {
        private String path = @"";

        public RepositorioAsistentesJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                 path = @"..\..\..\..\CoreAMTest\repos\Asistente.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\Asistente.json";
            }
        }





        private List<Asistente> leerAsistentes()
        {
            List<Asistente> asistentes;
            String jsonString = "";
            try
            {
                jsonString = File.ReadAllText(path);
                asistentes = System.Text.Json.JsonSerializer.Deserialize<List<Asistente>>(jsonString);

                foreach (Asistente a in asistentes)
                {
                    IRepositorioUsuario repo = Persistence.Factory.FabricaRepositorioUsuarios.CrearRepositorioUsuarios();
                    Usuario aux = repo.GetUsuario(a.IdUsuario);
                    a.setUsuario(aux);
                }

                return asistentes;
            }
            catch (JsonException)

            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }

            catch (Exception)

            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de Asistentes.");
            }
        }



        private void guardarAsistentes(List<Asistente> asistentes)
        {
            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(asistentes,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un problema al guardar el Asistente en el repositorio.");
            }
        }


      






        public Asistente agregarAsistente(Asistente asistente)
        {
            List<Asistente> asistentes = leerAsistentes();

            Asistente asitentesValidar = asistentes.Find((c) =>
            {
                return  c.Id == asistente.Id;
            });

            if (asitentesValidar != null)
            {
                throw new AsistenteDuplicadoException("Ya existe un Asistente con ese id");
            }
            asistentes.Add(asistente);

            this.guardarAsistentes(asistentes);


            // crear el estado de no pagado en la inscripcion

            return asistente;
        }






        public Asistente GetAsistente(int id)
        {
            List<Asistente> asistentes = leerAsistentes();
            Asistente asistente = asistentes.Find(c => c.Id == id);
            if (asistente == null)
            {
                throw new AsistenteNoEncontradaException($"el asistente con el {id} no fue encontrado.");
            }
            else
            {
                return asistente;
            }
        }

        public Asistente GetAsistenteprueba(int id)
        {
            List<Asistente> asistentes = leerAsistentes();
            Asistente asistente = asistentes.Find(c => c.Id == id);
            if (asistente == null)
            {
                return null;
            }
            else
            {
                return asistente;
            }
        }



    }


}
