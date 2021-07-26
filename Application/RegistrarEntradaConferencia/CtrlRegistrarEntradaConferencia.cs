using System;
using Domain.Conferencia;
using Persistence.Factory;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using RestSharp;
using System.Text.Json;
using System.Net;
using Domain.Common;
using System.Security.Permissions;
using Infrastructure.Sistema;
using Domain.Usuario;

namespace Application.RegistrarEntradaConferenciaPresencial
{
    public class CtrlRegistrarEntradaConferencia
    {
        private static string url_api = ConfigurationManager.AppSettings["url_api"];
        private IRepositorioAsistenciaConferencia repoAsistenciaConferencia;

        public CtrlRegistrarEntradaConferencia()
        {
            this.repoAsistenciaConferencia = FabricaRepositorioAsistenciaConferencia.CrearRepositorioAsistenciaConferencia();
        }
        public bool registrarEntradaPresencial(int conferenciaId, string identificacion, int eventoId, string api_value)
        {
            if (validaciones(conferenciaId, identificacion, eventoId))
            {
                Usuario user = Login.GetUsuario(api_value);

                if (user == null)
                {

                    throw new Exception("La api key usada no es valida");

                }
                return registrarAsistencia(identificacion, conferenciaId);
            }
            return false;

        }
        public string registrarEntradaVirtual(int conferenciaId, string identificacion, int eventoId, string api_value)
        {
            
            if (validaciones(conferenciaId, identificacion, eventoId))
            {

                Usuario user = Login.GetUsuario(api_value);

                if (user != null)
                {

                    Conferencia con = conferenciaEventoValida(conferenciaId, eventoId);
                    if(con == null)
                    {
                        throw new ConferenciaNoEncontradaException("no existe esa conferencia");
                    }
                    
                    
                    if(registrarAsistencia(identificacion, conferenciaId))
                    {
                        return con.Url;
                    }
                 
                    

                }
                else
                {
                    throw new Exception("La api key usada no es valida");

                }

            }
            return "";
        }
        private bool registrarAsistencia(string identificacion, int conferenciaId)
        {
            return repoAsistenciaConferencia.Agregar(new AsistenciaConferencia(identificacion, conferenciaId));

        }

        private Conferencia conferenciaEventoValida(int conferenciaId, int eventoId)
        {
            var client = new RestClient(url_api);
            var request = new RestRequest("api/gestionconferencia/conferencia/{value}", Method.GET);

            request.AddUrlSegment("value", conferenciaId);
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response);
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                Respuesta res = System.Text.Json.JsonSerializer.Deserialize<Respuesta>(response.Content, options);
                if (res.respuesta)
                {
                    string data = res.Data.ToString();
                    Conferencia conferencia = System.Text.Json.JsonSerializer.Deserialize<Conferencia>(data, options);
                    if (conferencia == null)
                    {
                        throw new ConferenciaNoEncontradaException("no existe la conferencia");
                    }
                    if (conferencia.EventoId == eventoId)
                    {
                        return conferencia;
                    }
                }
            }

            return null;

        }

        private bool validaciones(int conferenciaId, string identificacion, int eventoId)
        {
            if (conferenciaId <= 0)
            {
                throw new ValorIncorrectoException("id conferencia invalido");
            }
            if (eventoId <= 0)
            {
                throw new ValorIncorrectoException("id evento invalido");
            }
            if (identificacion == "")
            {
                throw new ValorIncorrectoException("identificación  invalido");
            }

            if (conferenciaEventoValida(conferenciaId, eventoId)== null)
            {
                throw new AsistenciaConferenciaException(" conferencia invalida ");
            }
            if (this.repoAsistenciaConferencia.GetAsistentesConferenciaRegistrado(conferenciaId, identificacion))
            {
                throw new AsistenciaConferenciaException("asistente con identificación: " + identificacion
                    + " ya esta registrado en la lista de asistentes de la conferencia");
            }
            return true;
        }


     
    }
}
