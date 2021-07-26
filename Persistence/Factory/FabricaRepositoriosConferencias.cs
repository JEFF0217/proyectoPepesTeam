using Domain.Conferencia;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositoriosConferencias
    {
        public static IRepositorioConferencias CrearRepositorioConferencias()
        {
            //var repo = ConfigurationManager.AppSettings["repository"];
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioConferenciasJSON(),
                _ => null,
            };
        }

    }
}
