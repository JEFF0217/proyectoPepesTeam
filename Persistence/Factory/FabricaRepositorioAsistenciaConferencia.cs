using Domain.Conferencia;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioAsistenciaConferencia
    {
        public static IRepositorioAsistenciaConferencia CrearRepositorioAsistenciaConferencia()
        {
            var repo = ConfigurationManager.AppSettings["repository"];
            return repo switch
            {
                //"fake" => new  RepositorioAsistenciaConferenciaFake(),
                "json" => new RepositorioAsistenciaConferenciaJSON(),
                _ => null,
            };

        }
    }
}
