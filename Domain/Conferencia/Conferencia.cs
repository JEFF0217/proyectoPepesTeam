using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Conferencia
{
    public class Conferencia
    {
        public Conferencia()
        {
        }
        /// <summary>
        /// Atributos y Propiedades
        /// </summary>
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime HoraInicio { get; set; }
        public int Duracion { get; set; }

        public string Url { get; set; }


        public string Archivo { get; set; }

        public int EventoId { get; set; }
        public string AulaId { get; set; }
        public int ConferencistaId { get; set; }
        public List<int> RecursosId { get; set; }
    }
}
