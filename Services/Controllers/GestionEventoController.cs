using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.GestionarEvento;
using Domain.Evento;
using Domain.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GestionEventoController : ControllerBase
    {
        private CtrlGestionarEvento control;
        private Respuesta respuesta;

        public GestionEventoController()
        {
            respuesta = new Respuesta();
            control = new CtrlGestionarEvento();
        }
        // GET: api/<gestionEventoController>
        [HttpGet("eventos/{api_value}")]
        public Respuesta GetEventos(string api_value)
        {
            try
            {
                respuesta.Data = control.listarEventos(api_value);
                respuesta.mensaje = "se han obtenidos los eventos";
                respuesta.respuesta = true;
            }
            catch (Exception e)
            {
                respuesta.respuesta = false;
                respuesta.mensaje = e.Message;
            }
            return respuesta;
        }
        // GET: api/<gestionEventoController>
        [HttpGet("evento/{eventoid}/{api_value}")]
        public Respuesta GetConferencia(int eventoId,string api_value)
        {
            try
            {
                respuesta.Data = control.ObtenerEvento(eventoId,api_value);
                respuesta.mensaje = "Información obtenida correctamente.";
                respuesta.respuesta = true;
            }
            catch (Exception e)
            {
                respuesta.respuesta = false;
                respuesta.mensaje = e.Message;
            }
            return respuesta;
        }
        // POST api/<gestionEventoController>/5
        [HttpPost("{api_value}")]
        public Respuesta Post([FromBody] Evento evento,string  api_value)
        {
            try
            {
                respuesta.Data = control.agregarEvento(evento,api_value);
                respuesta.mensaje = "Evento creada correctamente.";
                respuesta.respuesta = true;
            }
            catch (Exception e)
            {
                respuesta.respuesta = false;
                respuesta.mensaje = e.Message;
            }
            return respuesta;
        }
        // PUT api/<gestionEventoController>/5
        [HttpPut("{id}/{api_value}")]
        public Respuesta Put(int eventoId, [FromBody] Evento evento,string api_value)
        {
            try
            {
                respuesta.Data = control.editarEvento(evento,api_value);
                respuesta.mensaje = "Evento editado correctamente.";
                respuesta.respuesta = true;

            }
            catch (Exception e)
            {
                respuesta.respuesta = false;
                respuesta.mensaje = e.Message;
            }
            return respuesta;
        }

        // DELETE api/<gestionEventoController>/5
        [HttpDelete("{id}/{api_value}")]
        public Respuesta Delete(int eventoId,string api_value)
        {
            try
            {
                respuesta.Data = control.eliminarEvento(eventoId,api_value);
                respuesta.mensaje = "Evento eliminado correctamente.";
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
