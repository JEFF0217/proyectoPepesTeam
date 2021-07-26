using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Evento
{
    public class Evento
    {
        public Evento()
        { }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int MinimoAsistentes { get; set; }
        public int MaximoAsistentes { get; set; }
        public string Lugar { get; set; }
        public string Ciudad { get; set; }
        public double Valor { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public EstadoEvento Estado { get; set; }


    }
}
