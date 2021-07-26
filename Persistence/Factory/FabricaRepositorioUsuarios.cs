using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Domain.Usuario;
using Persistence.JSON;

namespace Persistence.Factory
{
    public class FabricaRepositorioUsuarios
    {
        public static IRepositorioUsuario CrearRepositorioUsuarios()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioUsuariosJSON(),
                _ => null,
            };
        }

    }
}
