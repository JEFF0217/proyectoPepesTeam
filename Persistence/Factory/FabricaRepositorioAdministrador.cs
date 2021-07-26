using Domain.Administrador;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioAdministrador
    {
        public static IRepositorioAdministrador CrearRepositorioAdministrador()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioAdministradorJSON(),
                _ => null,
            };
        }
    }
}
