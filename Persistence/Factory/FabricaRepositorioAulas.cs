using Domain.Aula;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioAulas
    {
        public static IRepositorioAulas CrearRepositorioAulas()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioAulasJSON(),
                _ => null,
            };
        }

    }
}
