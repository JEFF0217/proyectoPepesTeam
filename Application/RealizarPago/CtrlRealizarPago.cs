using Domain.Pago;
using Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Application.RealizarPago
{
    public class CtrlRealizarPago
    {
        IRepositorioPagos repo;
        string url_api = ConfigurationManager.AppSettings["main"];

        public CtrlRealizarPago()
        {
            this.repo = FabricaRepositorioPagos.CrearRepositorioPagos();
        }

        public List<Pago> listarPagos(int eventoId, int AsistenteId)
        {
            IRepositorioPagos repo = FabricaRepositorioPagos.CrearRepositorioPagos();
            return repo.GetPagos(eventoId, AsistenteId);
        }

        public Pago agregarPagoEfectivo(int eventoId, string nombre, string descripcion,
            DateTime hora, int duracion, int AulaId, int ConferencistaId,
            List<int> RecursosId, string file)
        {
            //string dataFile = File.ReadAllText(file);
            //TODO: validar existencia de las claves foreneas
            Pago pago = new Pago();
            
            return null;
        }
    }
}
