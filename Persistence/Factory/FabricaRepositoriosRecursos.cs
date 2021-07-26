using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Domain.Recurso;
using Persistence.JSON;


namespace Persistence.Factory
{
    public class FabricaRepositoriosRecursos
    {
        public static IRepositorioRecursos CrearRepositorioRecursos()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioRecursosJSON(),
                _ => null,
            };


        }
    }
}
