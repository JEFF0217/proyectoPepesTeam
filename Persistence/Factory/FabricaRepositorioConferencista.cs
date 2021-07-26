using Domain.Conferencista;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioConferencista
    {
        public static IRepositorioConferencistas CrearRepositorioConferencistas()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioConferencistasJSON(),
                _ => null,
            };
        }
    }
}
