using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Organizador
{
    public interface IRepositorioOrganizadores
    {
        List<Organizador> GetOrganizadores();
    }
}
