using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Conferencista
{
    public interface IRepositorioConferencistas
    {
        List<Conferencista> GetConferencistas(int ConferenciaId,string queryNombre = "");

        Conferencista GetConferencista(int Id);

        Conferencista Agregar(Conferencista Conferencista);

        Conferencista Editar(Conferencista ConferencistaNew);

        Conferencista Eliminar(int Id);
    }
}
