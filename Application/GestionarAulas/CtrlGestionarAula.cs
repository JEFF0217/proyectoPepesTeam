using System;
using System.Collections.Generic;
using System.Text;
using Persistence.Factory;
using Domain.Aula;
using Domain.Evento;
using Domain.Conferencia;
using Domain.Common;

namespace Application.GestionarAulas
{
    public class CtrlGestionarAula
    {
        IRepositorioAulas repoAulas;
        IRepositorioEventos repoEventos;
        IRepositorioConferencias repoConferencias;


        public CtrlGestionarAula()
        {
            this.repoAulas = FabricaRepositorioAulas.CrearRepositorioAulas();
            this.repoEventos = FabricaRepositorioEventos.CrearRepositorioEventos();
            this.repoConferencias = FabricaRepositoriosConferencias.CrearRepositorioConferencias();
        }

        public List<Aula> ListarAulas(int eventoId)
        {
            if (eventoId > 0)
            {
                IRepositorioAulas repo = FabricaRepositorioAulas.CrearRepositorioAulas();

                return this.repoAulas.GetAulas(eventoId);
            }
            else
            {
                throw new Domain.Common.ValorIncorrectoException("el evento no existe");
            }

        }


        public Aula agregarAula(Aula aula)
        {
            repoEventos.GetEvento(aula.EventoId);

            if (aula != null)
            {
                if (aula.Id == null || aula.Id == "")
                {
                    throw new ValorIncorrectoException("Debe ingresar un id valido para el Aula");
                }

                if (aula.Capacidad <= 0)
                {

                    throw new ValorIncorrectoException("Debe ingresar una capacidad valida para el Aula");
                }
                return repoAulas.Agregar(aula);
            }

            {
                throw new ValorIncorrectoException("debe ingresar los valores obligatorios");
            }

        }



        public Aula editarAula(Aula aula)
        {
            repoEventos.GetEvento(aula.EventoId);

            if (aula != null)
            {
                if (aula.Id == null || aula.Id == "")
                {
                    throw new ValorIncorrectoException("Debe ingresar un id valido para el Aula");
                }

                if (aula.Capacidad <= 0)
                {

                    throw new ValorIncorrectoException("Debe ingresar una capacidad valida para el Aula");
                }
                return repoAulas.Editar(aula);
            }

            {
                throw new ValorIncorrectoException("debe ingresar los valores obligatorios");
            }
        }


        public List<Aula> ListarAulasDisponibles(DateTime inicio, int duracion, int eventoId)
        {
            List<Conferencia> conferencias = repoConferencias.GetConferencias(eventoId);

            List<Aula> aulasEvt= new List<Aula>();

            foreach (Conferencia c in conferencias)
            {
                if (c.HoraInicio >= inicio && inicio.AddMinutes(duracion) >= c.HoraInicio.AddMinutes(c.Duracion))

                {
                    
                        Aula aula = repoAulas.GetAula(c.AulaId,eventoId);
                        aulasEvt.Add(aula);
                    
                }
            }

            return aulasEvt;
        }
         





        public bool eliminarAula(string id, int eventoId)
        {
            repoEventos.GetEvento(eventoId);

            if (id != null || id != "")
            {

                return repoAulas.Eliminar(id, eventoId);
            }
            else
            {
                throw new ValorIncorrectoException("El id del aula es incorrecto");
            }
        }











        public Aula obtenerAula(string id, int eventoId)
        {
            repoEventos.GetEvento(eventoId);

            if (id != null || id != "" )
            {

                return repoAulas.GetAula(id, eventoId);
            }
            else
            {
                throw new ValorIncorrectoException("El id del aula es incorrecto");
            }

        }





    }
}
