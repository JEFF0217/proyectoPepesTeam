using Domain.Organizador;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioOrganizadores
    {
        public static IRepositorioOrganizadores CrearRepositorioConferencias()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioOrganizadoresJSON(),
                _ => null,
            };
        }
    }
}
