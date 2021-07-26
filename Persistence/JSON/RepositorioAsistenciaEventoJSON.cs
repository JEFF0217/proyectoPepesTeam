using Domain.Evento;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Persistence.JSON
{
    class RepositorioAsistenciaEventoJSON : IRepositorioAsistenciaEvento
    {
        private String path = @"..\CoreAMTest\repos\asistenciaEvento.json";

        public RepositorioAsistenciaEventoJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\asistenciaEvento.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\asistenciaEvento.json";
            }
        }


        public bool Agregar(AsistenciaEvento asistente)
        {
            List<AsistenciaEvento> asistentesEvento = leerAsistenciaEvento();
            asistentesEvento.Add(asistente);
            return guardarAsistenciaEvento(asistentesEvento);

        }

        public bool GetAsistentesEventoRegistrado(int eventoId, string identificacion)
        {
            List<AsistenciaEvento> asistentesEvento = leerAsistenciaEvento();
            return asistentesEvento.Exists(a => a.eventoId == eventoId && a.identificacionAsistente == identificacion);

        }

        private List<AsistenciaEvento> leerAsistenciaEvento()
        {
            try
            {
                string json = File.ReadAllText(path);
                return System.Text.Json.JsonSerializer.Deserialize<List<AsistenciaEvento>>(json);
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception e)
            {
                throw new AsistenciaEventoException("Ocurrió un porblema al acceder al repositorio de asistentes eventos.");
            }
        }

        private bool guardarAsistenciaEvento(List<AsistenciaEvento> asistentesEvento)
        {
            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(asistentesEvento,
                                   Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
                return true;
            }
            catch (Exception)
            {
                throw new AsistenciaEventoException("Ocurrió un error al guardar la información en el repositorio de datos");
            }
        }
    }
}

