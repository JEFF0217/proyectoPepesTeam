using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Evento
{
    public interface IRepositorioEventos
    {
        List<Evento> GetEventos();

        Evento GetEvento(int eventoId);

        Evento Agregar(Evento evento);

        Evento Editar(Evento evento);

        bool Eliminar(int eventoid);

    }
}
