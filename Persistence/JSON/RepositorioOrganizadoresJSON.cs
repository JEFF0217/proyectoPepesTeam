using Domain.Organizador;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Persistence.JSON
{
    class RepositorioOrganizadoresJSON: IRepositorioOrganizadores
    {
        public List<Organizador> GetOrganizadores()
        {
            List<Organizador> organizadores;

            String path = @".\.\..\..\..\repos\proyecto-del-curso-pepe-s-team\CoreAMTest\proyecto-del-curso-pepe-s-team\CoreAMTest\organizadores.json";
            String jsonString = File.ReadAllText(path);

            organizadores = System.Text.Json.JsonSerializer.Deserialize<List<Organizador>>(jsonString);

            return organizadores;

        }
    }
}
