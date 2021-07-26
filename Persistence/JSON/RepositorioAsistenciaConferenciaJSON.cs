using Domain.Conferencia;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
namespace Persistence.JSON
{
#pragma warning disable CS0535 // 'RepositorioAsistenciaConferenciaJSON' no implementa el miembro de interfaz 'IRepositorioAsistenciaConferencia.GetAsistentesConferencia(int)'
    class RepositorioAsistenciaConferenciaJSON : IRepositorioAsistenciaConferencia
#pragma warning restore CS0535 // 'RepositorioAsistenciaConferenciaJSON' no implementa el miembro de interfaz 'IRepositorioAsistenciaConferencia.GetAsistentesConferencia(int)'
    {
        private String path = @"";

        public RepositorioAsistenciaConferenciaJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\asistenciaConferencia.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\asistenciaConferencia.json";
            }
        }


        public bool Agregar(AsistenciaConferencia asistente)
        {
            List<AsistenciaConferencia> asistentesConferencia = leerAsistenciaConferencia();
            asistentesConferencia.Add(asistente);
            return guardarAsistenciaConferencia(asistentesConferencia);
            
        }

      

        private List<AsistenciaConferencia> leerAsistenciaConferencia()
        {
            try
            {

                string json = File.ReadAllText(path);
                return System.Text.Json.JsonSerializer.Deserialize<List<AsistenciaConferencia>>(json);
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new AsistenciaConferenciaException("Ocurrió un porblema al acceder al repositorio de asistentes conferencias.");
            }
        }

        private bool guardarAsistenciaConferencia(List<AsistenciaConferencia> asistentesEvento)
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
                throw new AsistenciaConferenciaException("Ocurrió un error al guardar la información en el repositorio de datos");
            }
        }

        public bool GetAsistentesConferenciaRegistrado(int conferneciaId, string identificacion)
        {
            List<AsistenciaConferencia> asistentesConferencia = leerAsistenciaConferencia();
            return asistentesConferencia.Exists(a => a.conferenciaId == conferneciaId && a.identificacionAsistente == identificacion);
        }

        public List<string> GetAsistentesConferencia(int conferneciaId)
        {
            throw new NotImplementedException();
        }
    }
}
