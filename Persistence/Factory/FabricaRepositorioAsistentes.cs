using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Domain.Asistente;
using Persistence.JSON;

namespace Persistence.Factory
{
    public class FabricaRepositorioAsistentes
    {
        public static IRepositorioAsistente CrearRepositorioAsistentess()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch

            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioAsistentesJSON(),
                _ => null,
            };
        }
    }
}
