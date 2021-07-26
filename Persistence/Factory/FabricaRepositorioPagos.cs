using Domain.Pago;
using Persistence.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistence.Factory
{
    public class FabricaRepositorioPagos
    {
        public static IRepositorioPagos CrearRepositorioPagos()
        {
            var repo = ConfigurationManager.AppSettings["repository"];
            return repo switch


            {
                //"fake" => new RepositorioEspecialidadesFake(),
                "json" => new RepositorioPagosJSON(),
                _ => null,
            };
        }
    }
}
