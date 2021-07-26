using Domain.Evento;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioEstadoEvento
    {
        public static IRepositorioEstadoEvento CrearRepositorioEstadoEvento()
        {
            var repo = ConfigurationManager.AppSettings["repository"];
            return repo switch
            {
                //"fake" => new  RepositorioAsistenciaConferenciaFake(),
                "json" => new RepositorioEstadoEventoJSON(),
                _ => null,
            };

        }
    }
}
