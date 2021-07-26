using Domain;
using Domain.Evento;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Persistence.JSON
{
    public class RepositorioEstadoEventoJSON : IRepositorioEstadoEvento
    {
        private String path = @"..\CoreAMTest\repos\conferencias.json";

        public RepositorioEstadoEventoJSON()
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

        public bool SetEstado(int id, EstadoEvento estado)
        {
            string json = "";
            try
            {
                json = File.ReadAllText(path);
            }
            catch (Exception)
            {
                throw new Exception("No se logro acceder al repositoriod de datos correctamente.");
            }
            List<Evento> eventos;

            try
            {
                eventos = System.Text.Json.JsonSerializer.Deserialize<List<Evento>>(json);
            }
            catch (Exception)
            {
                throw new Exception("El formaro de los datos en el repositorio de datos es incorrecto.");
            }

            Evento evento;
            evento = eventos.Find(c => c.Id == id);


            if (evento != null)
            {
                try
                {

                    evento.Estado = estado;
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(eventos, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(path, output);
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("No se lograron guardar los datos en el repositorio");
                }
            }
            else
            {
                throw new EventoNoEncontradoException($"No se encontro ningún evento con el id {id}");
            }

        }

    }
}
