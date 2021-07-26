using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Administrador
{
    public interface IRepositorioAdministrador
    {
        List<Administrador> GetAdministrador();
    }
}
