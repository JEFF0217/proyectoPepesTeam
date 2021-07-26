using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.RegistrarEntradaEvento;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaEventoController : ControllerBase
    {
        private CtrlRegistrarEntradaEvento control;
        private Respuesta respuesta;

        public AsistenciaEventoController()
        {
            respuesta = new Respuesta();
            control = new CtrlRegistrarEntradaEvento();
        }

        // POST api/<AsistenciaEventoController>/5
        [HttpPost("presencial/{nombre}/{identificacion}/{eventoId}/{api_value}")]
        public Respuesta PostPresencial(string nombre, string identificacion, int eventoId, string api_value)
        {
            try
            {

                respuesta.mensaje = control.registrarEntradaPresencial(nombre, identificacion, eventoId, api_value);
                respuesta.respuesta = true;
            }
            catch (Exception e)
            {
                respuesta.respuesta = false;
                respuesta.mensaje = e.Message;
            }
            return respuesta;



        }
        // POST api/<AsistenciaEventoController>/5
        [HttpPost("virual/{identificacion}/{eventoId}/{api_value}")]
        public Respuesta PostVirtual(string identificacion, int eventoId, string api_value)
        {
            try
            {

                respuesta.mensaje = "melooo";
                respuesta.respuesta = control.registrarEntradaVirtual(identificacion, eventoId, api_value);
            }
            catch (Exception e)
            {
                respuesta.respuesta = false;
                respuesta.mensaje = e.Message;
            }
            return respuesta;



        }
    }
}
