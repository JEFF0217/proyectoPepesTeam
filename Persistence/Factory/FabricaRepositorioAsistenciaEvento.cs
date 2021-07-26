using Domain.Evento;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioAsistenciaEvento
    {

        public static IRepositorioAsistenciaEvento CrearRepositorioAsistenciaEvento()
        {
            var repo = ConfigurationManager.AppSettings["repository"];
            return repo switch
            {
                //"fake" => new  RepositorioAsistenciaEventoFake(),
                "json" => new RepositorioAsistenciaEventoJSON(),
                _ => null,
            };
           
        }

    }
}
