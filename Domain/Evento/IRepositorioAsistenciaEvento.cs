using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Evento
{
    public interface IRepositorioAsistenciaEvento
    {
        bool GetAsistentesEventoRegistrado(int eventoId, string identificacion);
        bool Agregar(AsistenciaEvento asistente);
    }
}
