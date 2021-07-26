using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Evento
{
    public class AsistenciaEvento
    {
        public AsistenciaEvento()
        {

        }
        public AsistenciaEvento(string identificacion, int eventoId)
        {
           
            this.identificacionAsistente = identificacion;
            this.eventoId = eventoId;
        }
        public string identificacionAsistente { get; set; }
        public int eventoId { get; set; }
    }
}
