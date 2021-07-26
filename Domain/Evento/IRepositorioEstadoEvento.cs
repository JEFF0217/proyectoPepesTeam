using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Evento
{
    public interface IRepositorioEstadoEvento
    {
        bool SetEstado(int eventoId, EstadoEvento estado);
    }
}
