using Domain.Administrador;
using Domain.Usuario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Persistence.JSON
{
    class RepositorioAdministradorJSON: IRepositorioAdministrador
    {
        public List<Administrador> GetAdministrador()
        {
            List<Administrador> administradores;

            String path = @".\..\..\..\repos\proyecto-del-curso-pepe-s-team\CoreAMTest\Administrador.json";
            String jsonString = File.ReadAllText(path);

            administradores = System.Text.Json.JsonSerializer.Deserialize<List<Administrador>>(jsonString);

            foreach (Administrador a in administradores)
            {
                IRepositorioUsuario repo = Persistence.Factory.FabricaRepositorioUsuarios.CrearRepositorioUsuarios();
                Usuario aux = repo.GetUsuario(a.IdUsuario);
                a.setUsuario(aux);
            }
            return administradores;

        }
    }
}
