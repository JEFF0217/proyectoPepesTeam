using Application.GestionarConferencia;
using Domain;
using Domain.Common;
using Domain.Evento;
using Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AutorizarEvento
{
    public class CtrlAutorizarEvento
    {
        public bool CambiarEstado(int eventoId,EstadoEvento estado)
        {
            if(eventoId < 0)
            {
                throw new ValorIncorrectoException("Debe de ingresar un evento valido");
            }

            if(estado  <= 0 || (int)estado >= 4)
            {
                throw new ValorIncorrectoException("Debe de ingresar un estado para el evento");
            }

            IRepositorioEstadoEvento repoEventos = FabricaRepositorioEstadoEvento.CrearRepositorioEstadoEvento();
            return repoEventos.SetEstado(eventoId, estado);
        }
    }
}
