using Domain.Conferencia;
using Domain.Evento;
using Domain.Recurso;
using Domain.Usuario;
using Infrastructure.Sistema;
using Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.GestionarRecusoso
{

    public class CtrlGestionarRecursos
    {
        IRepositorioRecursos repoRec;
#pragma warning disable CS0649 // El campo 'CtrlGestionarRecursos.repoConf' nunca se asigna y siempre tendrá el valor predeterminado null
        IRepositorioConferencias repoConf;
#pragma warning restore CS0649 // El campo 'CtrlGestionarRecursos.repoConf' nunca se asigna y siempre tendrá el valor predeterminado null
        public CtrlGestionarRecursos()
        {
            this.repoRec = FabricaRepositoriosRecursos.CrearRepositorioRecursos();
            this.repoConf = FabricaRepositoriosConferencias.CrearRepositorioConferencias();
        }

        public Recurso AdicionarRecusrsosConferencia(int recursoId, int conferenciaId, string api_value)
        {
            Usuario user = Login.GetUsuario(api_value);

            if (user == null)
            {
                throw new Exception("La api key usada no es valida");
            }
            else
            {
                Conferencia conferencia = repoConf.GetConferencia(conferenciaId);
                Recurso rec = repoRec.GetRecurso(recursoId);
                conferencia.RecursosId.Add(recursoId);
                repoConf.Editar(conferencia);
                return rec;
            }
        }

        public Recurso EliminarRecursoConferencia(int recursoId, int conferenciaId, string api_value)
        {
            Usuario user = Login.GetUsuario(api_value);

            if (user == null)
            {
                throw new Exception("La api key usada no es valida");
            }
            Conferencia conferencia = repoConf.GetConferencia(conferenciaId);
            List<int> listaRec = conferencia.RecursosId;
            if (!listaRec.Exists(r => r == recursoId))
            {
                throw new Exception($"Recurso no encontrado {recursoId} en la conferencia {conferenciaId}");
            }
            Recurso rec = repoRec.GetRecurso(recursoId);
            conferencia.RecursosId.Remove(recursoId);
            repoConf.Editar(conferencia);
            return rec;
        }

        public List<Recurso> ListarRecusos(int eventoId)
        {
            return this.repoRec.GetRecursos(eventoId);
        }


        //esta madre ni se si estara buena :v 
        public List<Recurso> ListarRecursosDisponibles(DateTime inicio, int duracion, int eventoId, string api_value)
        {
            Usuario user = Login.GetUsuario(api_value);

            if (user == null)
            {
                throw new Exception("La api key usada no es valida");
            }
            List<Conferencia> conferencias = repoConf.GetConferencias(eventoId);
            List<Recurso> recursosEvt = ListarRecusos(eventoId);
            if (recursosEvt.Count == 0)
            {
                throw new EventoNoEncontradoException($"No se encontro el evento {eventoId}");
            }
            foreach (Conferencia c in conferencias)
            {
                if (c.HoraInicio >= inicio && inicio.AddMinutes(duracion) >= c.HoraInicio.AddMinutes(c.Duracion))

                {
                    foreach (int id in c.RecursosId)
                    {
                        Recurso recurso = repoRec.GetRecurso(id);
                        recursosEvt.Remove(recurso);
                    }
                }
            }
            return recursosEvt;
        }

        public List<Recurso> ListarRecursosConferencia(int conferenciaId, string api_value)
        {
            Usuario user = Login.GetUsuario(api_value);

            if (user == null)
            {
                throw new Exception("La api key usada no es valida");
            }
            Conferencia conferencia = repoConf.GetConferencia(conferenciaId);
            List<Recurso> recursosConferencia = new List<Recurso>();
            foreach (int id in conferencia.RecursosId)
            {
                Recurso recurso = repoRec.GetRecurso(id);
                recursosConferencia.Add(recurso);
            }
            return recursosConferencia;
        }

    }
}
