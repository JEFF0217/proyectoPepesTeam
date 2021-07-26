using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Recurso
{
    public interface IRepositorioRecursos
    {
        List<Recurso> GetRecursos(int EventoId);

        Recurso GetRecurso(int recursoId);

        Recurso EliminarRecusoConferencia(int recursoId, int conferenciaId);

        Recurso AgregarRecusoConferencia(int recursoId, int conferenciaId);

    }
}
