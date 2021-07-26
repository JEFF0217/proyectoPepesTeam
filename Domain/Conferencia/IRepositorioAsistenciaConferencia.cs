using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Conferencia
{
    public interface IRepositorioAsistenciaConferencia
    {
        List<string> GetAsistentesConferencia(int conferneciaId);

        bool GetAsistentesConferenciaRegistrado(int conferneciaId, string identificacion);

        bool Agregar(AsistenciaConferencia asistente);
    }
}
