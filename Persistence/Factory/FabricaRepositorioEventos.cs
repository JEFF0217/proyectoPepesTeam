using Domain.Evento;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioEventos
    {
        public static IRepositorioEventos CrearRepositorioEventos()
        {
            var repo = ConfigurationManager.AppSettings["repository"];

            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioEventosJSON(),
                _ => null,
            };
        }
    }
}
