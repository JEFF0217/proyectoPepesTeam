using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Conferencia
{
    public class AsistenciaConferencia
    {
        public AsistenciaConferencia()
        {

        }
        public AsistenciaConferencia(string identificacion, int conferenciaId)
        {
            this.conferenciaId= conferenciaId;
            this.identificacionAsistente = identificacion;
        
        }
        public string identificacionAsistente { get; set; }
       
        public int conferenciaId { get; set; }
    }
}
