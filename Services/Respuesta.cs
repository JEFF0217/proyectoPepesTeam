using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Controllers
{
    public class Respuesta
    {
        public Respuesta()
        {
            respuesta = false;
        }
        public bool respuesta { get; set; }
        public string mensaje { get; set; }

        public Object Data { get; set; }
    }
}
