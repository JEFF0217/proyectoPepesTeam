using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pago
{
    public class Pago
    {
        public double Valor { get; set; }
        public TipoPago TipoPago { get; set; }
        public DateTime Fecha { get; set; }
        public string NumTarjeta { get; set; }
        public int AsistenteId { get; set; }
        public int EventoId { get; set; }
        public int IdPago { get; set; }
        
    }
}
