using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Inscripcion
{
    public class Inscripcion
    {
        public int AsistenteId { get; set; }
        public int eventoId { get; set; }
        public estadoPago estado { get; set; }

    }
}
