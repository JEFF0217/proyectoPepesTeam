using Domain.Aula;
using Domain.Common;
using Domain.Conferencia;
using Domain.Evento;
using Domain.Recurso;
using Persistence.Factory;
using Infrastructure.Sistema;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using Domain.Usuario;

namespace Application.GestionarConferencia
{
    public class CtrlGestionarConferencia
    {
        IRepositorioConferencias repoConferencias;
        IRepositorioRecursos repoRecursos;
        IRepositorioEventos repoEventos;
        IRepositorioAulas repoAulas;

        public CtrlGestionarConferencia()
        {
            this.repoConferencias = FabricaRepositoriosConferencias.CrearRepositorioConferencias();
            this.repoRecursos = FabricaRepositoriosRecursos.CrearRepositorioRecursos();
            this.repoEventos = FabricaRepositorioEventos.CrearRepositorioEventos();
            this.repoAulas = FabricaRepositorioAulas.CrearRepositorioAulas();
        }

        public List<Conferencia> listarConferencias(int eventoId, string queryNombre = "")
        {
            if (eventoId > 0)
            {
                repoEventos.GetEvento(eventoId);
                return repoConferencias.GetConferencias(eventoId, queryNombre);
            }
            else
            {
                throw new ValorIncorrectoException("El valor ingresado para el evento es incorrecto.");
            }

        }

        public Conferencia agregarConferencia(Conferencia conferencia,string api_value)
        {
            if (conferencia != null)
            {
                Evento evento = repoEventos.GetEvento(conferencia.EventoId);

                Usuario user = Login.GetUsuario(api_value);

                if(user == null)
                {
                    throw new Exception("La api key usada no es valida");
                }

                if (conferencia.Nombre == null || conferencia.Nombre == "")
                {
                    throw new ValorIncorrectoException("Debe ingresar un nombre valido para la conferencia.");
                }


                if (conferencia.Duracion <= 2 || conferencia.Duracion >= 20)
                {
                    throw new ValorIncorrectoException("La duración de la conferencias debe de estar entre 3 y 20 minutos");
                }


                return repoConferencias.Agregar(conferencia);
            }
            else
            {
                throw new ValorIncorrectoException("Debe de ingresar valores en el formato de la conferencia.");

            }
        }
        public Conferencia editarConferencia(Conferencia conferencia)
        {
            if (conferencia != null)
            {
                repoConferencias.GetConferencia(conferencia.Id);

                repoEventos.GetEvento(conferencia.EventoId);

                if (conferencia.Nombre == null || conferencia.Nombre == "")
                {
                    throw new ValorIncorrectoException("Debe ingresar un nombre valido para la conferencia.");
                }


                if (conferencia.Duracion <= 2 || conferencia.Duracion >= 20)
                {
                    throw new ValorIncorrectoException("La duración de la conferencias debe de estar entre 3 y 20 minutos");
                }

                //validar la disponibilidad de aula, conferencia y recursos

                return repoConferencias.Editar(conferencia);
            }
            else
            {
                throw new ValorIncorrectoException("Debe de ingresar valores en el formato de la conferencia.");

            }
        }

        public bool eliminarConferencia(int conferenciaId)
        {
            if (conferenciaId > 0)
            {
                return repoConferencias.Eliminar(conferenciaId);
            }
            else
            {
                throw new ValorIncorrectoException("El id de la conferencias es invalido");
            }

        }

        public Conferencia ObtenerConferencia(int id)
        {
            if (id > 0)
            {
                return repoConferencias.GetConferencia(id);
            }
            else
            {
                throw new ValorIncorrectoException("El id de la conferencia es invalido");
            }
        }


    }
}
