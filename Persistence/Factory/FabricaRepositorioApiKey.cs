using Domain.ApiKey;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioApiKey
    {
        public static IRepositorioApiKey CrearRepositorioApiKey()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch
            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioApiKeyJSON(),
                _ => null,
            };
        }
    }
}
