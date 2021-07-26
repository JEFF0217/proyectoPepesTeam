using Domain.Conferencia;
using Domain.Recurso;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Persistence.JSON
{
    public class RepositorioRecursosJSON : IRepositorioRecursos
    {
        private String path = @"";

        public RepositorioRecursosJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\recursos.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\recursos.json";
            }
        }

        private List<Recurso> leerRecursos()
        {
            List<Recurso> recursos;
            String jsonString = "";
            try
            {
                jsonString = File.ReadAllText(path);
                recursos = System.Text.Json.JsonSerializer.Deserialize<List<Recurso>>(jsonString);
                return recursos;
            }
            catch (JsonException e)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de conferencias.");
            }
        }


        public List<Recurso> GetRecursos(int EventoId)
        {
            List<Recurso> recursos = leerRecursos();
            try
            {
                recursos = recursos
                    .FindAll(c =>
                    {
                        return c.EventoId == EventoId;
                    });

                return recursos;
            }
            catch (JsonException e)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de recursos.");
            }
        }

        public Recurso GetRecurso(int recursoId)
        {
            Recurso recurso = this.leerRecursos().FirstOrDefault(u => u.Id == recursoId);
            if (recurso == null)
            {
                throw new RecursoNoEncontradoException($"no se encontro el recurso con id {recursoId}");
            }
            return recurso;
        }

        
        public Recurso EliminarRecusoConferencia(int recursoId, int conferenciaId)
        {
            throw new NotImplementedException();
        }

        public Recurso AgregarRecusoConferencia(int recursoId, int conferenciaId)
        {
            throw new NotImplementedException();
        }

    }
}
