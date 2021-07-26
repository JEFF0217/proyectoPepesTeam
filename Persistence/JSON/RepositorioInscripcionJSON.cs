using Domain.Inscripcion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Persistence.JSON
{
    public class  RepositorioInscripcionJSON : IRepositorioInscripcion
    {

        private String path = @"";
        public RepositorioInscripcionJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\repos\inscripcion.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\inscripcion.json";
            }
        }


        private List<Inscripcion> leerInscripcion()
        {
            List<Inscripcion> inscripciones;
            String jsonString = "";
            try
            {
                jsonString = File.ReadAllText(path);
                inscripciones = System.Text.Json.JsonSerializer.Deserialize<List<Inscripcion>>(jsonString);
                return inscripciones;
            }
            catch (JsonException)

            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }

            catch (Exception)

            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de inscripciones.");
            }
        }



        private void guardarAsistentes(List<Inscripcion> inscripciones)
        {
            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(inscripciones,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un problema al guardar la inscripcion en el repositorio.");
            }
        }









        public Inscripcion agregar (Inscripcion inscripcion) { 
            List<Inscripcion> inscripciones = leerInscripcion();

            Inscripcion inscripsionesValidar = inscripciones.Find((c) =>
            {
                return c.eventoId == inscripcion.eventoId && c.AsistenteId == inscripcion.AsistenteId;
            });

            if (inscripsionesValidar != null)
            {
                throw new InscripcionDuplicadaException("Ya existe una Inscripcion con ese nombre");
            }
            inscripciones.Add(inscripcion);

            this.guardarAsistentes(inscripciones);


            // crear el estado de no pagado en la inscripcion

            return inscripcion;
        }

    }
}
