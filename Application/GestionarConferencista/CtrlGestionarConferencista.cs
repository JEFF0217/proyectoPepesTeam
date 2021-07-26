using Domain.Common;
using Domain.Conferencia;
using Domain.Conferencista;
using Domain.Evento;
using Domain.Recurso;
using Persistence.Factory;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Application.GestionarConferencista
{
    public class CtrlGestionarConferencista
    {
        IRepositorioConferencistas repo;
        IRepositorioConferencias repoConferencias;

        string url_api = ConfigurationManager.AppSettings["main"];

        public CtrlGestionarConferencista()
        {
            this.repo = FabricaRepositorioConferencista.CrearRepositorioConferencistas();
            this.repoConferencias = FabricaRepositoriosConferencias.CrearRepositorioConferencias();
        }

        public List<Conferencista> listarConferencistas(int ConferenciaId, string queryNombre = "")
        {

            if (ConferenciaId> 0)
            {
                return repo.GetConferencistas(ConferenciaId, queryNombre);
            }
            else
            {
                throw new ValoresIncorrectosException("El valor ingresado para el conferencista es incorrecto.");
            }
        }

        public Conferencista agregarConferencista(Conferencista conferencista)
        {
            
            //TODO: validar existencia de las claves foreneas
            if (conferencista != null)
            {
                repoConferencias.GetConferencia(conferencista.Id);

                if (conferencista.Nombre == null || conferencista.Nombre == "")
                {
                    throw new ValorIncorrectoException("Debe ingresar un nombre valido para el conferencista.");
                }

                //validar la disponibilidad de aula, conferencia y recursos


                return repo.Agregar(conferencista);
            }
            else
            {
                throw new ValorIncorrectoException("Debe de ingresar valores en el formato de el conferencista.");
            }
           
        }

        public Conferencista editarConferencista(Conferencista conferencista)
        {
            if (conferencista != null)
            {
                repoConferencias.GetConferencia(conferencista.ConferenciaId);

                if (conferencista.Nombre == null || conferencista.Nombre == "")
                {
                    throw new ValorIncorrectoException("Debe ingresar un nombre valido para el conferencista.");
                }


                if (conferencista.Identificacion == null || conferencista.Identificacion == "")
                {
                    throw new ValorIncorrectoException("Debe ingresar la identificacion del conferencista");
                }

                //validar la disponibilidad de aula, conferencia y recursos

                return repo.Editar(conferencista);
            }
            else
            {
                throw new ValorIncorrectoException("Debe de ingresar valores en el formato del conferencista.");

            }
        }

        public Conferencista eliminarConferencista(int conferencistaId)
        {
            if (conferencistaId > 0)
            {
                return repo.Eliminar(conferencistaId);
            }
            else
            {
                throw new ValorIncorrectoException("El id del conferencista es invalido");
            }
        }

        public Conferencista ObtenerConferencista(int id)
        {
            if (id > 0)
            {
                return repo.GetConferencista(id);
            }
            else
            {
                throw new ValorIncorrectoException("El id del conferencista es invalido");
            }
            
        }

        

    }
}
