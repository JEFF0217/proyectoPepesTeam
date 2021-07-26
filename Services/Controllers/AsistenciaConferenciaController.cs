using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.RegistrarEntradaConferenciaPresencial;
using Domain.Conferencia;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaConferenciaController : ControllerBase
    {
        private CtrlRegistrarEntradaConferencia control;
        private Respuesta respuesta;

        public AsistenciaConferenciaController()
        {
            respuesta = new Respuesta();
            control = new CtrlRegistrarEntradaConferencia();
        }
        // POST api/<AsistenciaConferenciaController>
        [HttpPost("presencial/{conferenciaId}/{identificacion}/{eventoId}/{api_value}")]
        public Respuesta PostPresencial(int conferenciaId, string identificacion, int eventoId, string api_value)
        {
            try
            {
               
                respuesta.mensaje = "melo sisas melo";
                respuesta.respuesta = control.registrarEntradaPresencial(conferenciaId, identificacion, eventoId, api_value);
            }
            catch (Exception e)
            {
                respuesta.respuesta = false;
                respuesta.mensaje = e.Message;
            }
            return respuesta;


            
        }
        // POST api/<AsistenciaConferenciaController>
        [HttpPost("virual/{conferenciaId}/{identificacion}/{eventoId}/{api_value}")]
        public Respuesta PostVirtual(int conferenciaId, string identificacion, int eventoId, string api_value)
        {
            try
            {

                respuesta.mensaje = control.registrarEntradaVirtual(conferenciaId, identificacion, eventoId, api_value);
                respuesta.respuesta = true;
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
