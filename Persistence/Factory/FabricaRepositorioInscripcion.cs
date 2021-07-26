using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Domain.Inscripcion;
using Persistence.JSON;

namespace Persistence.Factory
{
    public class FabricaRepositorioInscripcion
    {
        public static IRepositorioInscripcion CrearRepositorioInscripcion()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioInscripcionJSON(),
                _ => null,
            };
        }
    }
}
