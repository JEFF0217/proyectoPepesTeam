using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pago
{
    public interface IRepositorioPagos
    {
        List<Pago> GetPagos(int EventoId, int AsistenteId);
        Pago GetPago(int Id);
        Pago AgregarPagoEfectivo(Pago Pago);
        Pago AgregarPagoTarjeta(Pago Pago);
    }
}
