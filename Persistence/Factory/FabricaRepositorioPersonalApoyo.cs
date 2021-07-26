using Domain.PersonalApoyo;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioPersonalApoyo
    {
        public static IRepositorioPersonalApoyo CrearRepositorioPersonalApoyo()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioPersonalApoyoJSON(),
                _ => null,
            };
        }
    }
}
