using System;
using Domain.Evento;
using Persistence.Factory;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Text.Json;
using Domain.Common;
using System.Net;
using Domain.Usuario;
using Infrastructure.Sistema;
using System.Configuration;

namespace Application.RegistrarEntradaEvento
{
    public class CtrlRegistrarEntradaEvento
    {
        private IRepositorioAsistenciaEvento repoAsistenciaEvento;
        private static string url_api = ConfigurationManager.AppSettings["url_api"];
        public CtrlRegistrarEntradaEvento()
        {
            this.repoAsistenciaEvento = FabricaRepositorioAsistenciaEvento.CrearRepositorioAsistenciaEvento();
        }
        public string registrarEntradaPresencial(string nombre, string identificacion, int eventoId, string api_value)
        {
            string resultado = "";
            if (validaciones(identificacion, eventoId))
            {

                Usuario user = Login.GetUsuario(api_value);

                if (user == null)
                {

                    throw new Exception("La api key usada no es valida");

                }

                if (registrarAsistencia(identificacion, eventoId))
                {
                    return obtenerEscarapela(identificacion, user.Nombre, eventoId);
                }

            }

            return resultado;
        }
        public bool registrarEntradaVirtual(string identificacion, int eventoId, string api_value)
        {
            if (validaciones(identificacion, eventoId))
            {
                Usuario user = Login.GetUsuario(api_value);

                if (user == null)
                {

                    throw new Exception("La api key usada no es valida");

                }
                return registrarAsistencia(identificacion, eventoId);
            }

            return false;
        }
        private bool registrarAsistencia(string identificacion, int eventoId)
        {
            return repoAsistenciaEvento.Agregar(new AsistenciaEvento(identificacion, eventoId));

        }

        private bool asistenteRegistroEvento(string identificacion, int eventoId)
        {
            return true;
        }

        private bool validaciones(string identificacion, int eventoId)
        {
            if (eventoId <= 0)
            {
                throw new ValorIncorrectoException("id evento invalido");
            }
            if (identificacion == "")
            {
                throw new ValorIncorrectoException("identificación  invalido");
            }
            if (!asistenteRegistroEvento(identificacion, eventoId))
            {
                throw new AsistenciaEventoException("asistente con identificación: " + identificacion
                    + " no se encuentra registrado en el evento");
            }
            if (this.repoAsistenciaEvento.GetAsistentesEventoRegistrado(eventoId, identificacion))
            {
                throw new AsistenciaEventoException("asistente con identificación: " + identificacion
                    + " ya esta registrado en la lista de asistentes del evento");
            }
            return true;
        }

        private string obtenerEscarapela(string identificacion, string nombre, int eventoId)
        {
            var client = new RestClient(url_api);
            var request = new RestRequest("api/generarescarapela/{value1}/{value2}/{value3}/{value4}", Method.GET);

            request.AddUrlSegment("value1", eventoId);
            request.AddUrlSegment("value2", nombre);
            request.AddUrlSegment("value3", "fake");
            request.AddUrlSegment("value4", identificacion);
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response);
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                Respuesta res = System.Text.Json.JsonSerializer.Deserialize<Respuesta>(response.Content, options);

                if (!res.respuesta)
                {
                    throw new ValorIncorrectoException("no existe la conferencia");
                }
                if (res.mensaje == "")
                {
                    throw new ValorIncorrectoException("no existe la conferencia");
                }
                return res.mensaje;


            }
            return "";

        }
    }
}
