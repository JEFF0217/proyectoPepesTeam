using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Asistente
{
    public interface IRepositorioAsistente
    {
        Asistente GetAsistente(int id);
        Asistente GetAsistenteprueba(int id);

        Asistente agregarAsistente(Asistente asistente);
    }
}
