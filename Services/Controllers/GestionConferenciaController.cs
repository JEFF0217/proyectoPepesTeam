using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.GestionarConferencia;
using Domain.Common;
using Domain.Conferencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestionConferenciaController : ControllerBase
    {
        private CtrlGestionarConferencia control;

        public GestionConferenciaController()
        {
            control = new CtrlGestionarConferencia();
        }

        // GET: api/<GestionConferenciaController>
        [HttpGet("conferencias/{eventoId}")]
        public Respuesta GetConferencias(int eventoId)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Listado obtenido correctamente.";
                res.Data = control.listarConferencias(eventoId);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }

        // GET api/<GestionConferenciaController>/5
        [HttpGet("conferencia/{id}")]
        public Respuesta GetConferencia(int id)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Información obtenida correctamente.";
                res.Data = control.ObtenerConferencia(id);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }

        // POST api/<GestionConferenciaController>
        [HttpPost("{api_value}")]
        public Respuesta Post([FromBody] Conferencia conferencia,string api_value)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Conferencia creada correctamente.";
                res.Data = control.agregarConferencia(conferencia,api_value);
            }
            catch (Exception e)
            {
                res.respuesta = false;  
                res.mensaje = e.Message;
            }
            return res;
        }

        // PUT api/<GestionConferenciaController>/5
        [HttpPut]
        public Respuesta Put([FromBody] Conferencia conferencia)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Conferencia editada correctamente.";
                res.Data = control.editarConferencia(conferencia);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }

        // DELETE api/<GestionConferenciaController>/5
        [HttpDelete("{id}")]
        public Respuesta Delete(int id)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Conferencia eliminada correctamente.";
                res.Data = control.eliminarConferencia(id);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }
    }
}
