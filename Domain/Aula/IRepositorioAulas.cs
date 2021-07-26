using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Aula
{
    public interface IRepositorioAulas
    {
        List<Aula> GetAulas(int EventoId);

        Aula GetAula(string id, int eventoId);      

        bool Eliminar(string id, int eventoId);

        Aula Agregar(Aula aula);

        Aula Editar(Aula aula);


    }
}
