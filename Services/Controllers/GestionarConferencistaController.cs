using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.GestionarConferencista;
using Domain.Conferencista;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionarConferencistaController : ControllerBase
    {

        private CtrlGestionarConferencista control;

        public GestionarConferencistaController()
        {
            control = new CtrlGestionarConferencista();
        }

        // GET: api/<GestionarConferencistaController>
        [HttpGet("conferencistas/{conferenciaId}")]
        public Respuesta GetConferencistas(int conferenciaId)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Listado obtenido correctamente.";
                res.Data = control.listarConferencistas(conferenciaId);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }

        // GET api/<GestionarConferencistaController>/5
        [HttpGet("conferencista/{id}")]
        public Respuesta GetConferencista(int id)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Información obtenida correctamente.";
                res.Data = control.ObtenerConferencista(id);
            }
            catch (Exception e)
            {
                res.mensaje = e.Message;
            }
            return res;
        }

        // POST api/<GestionarConferencistaController>
        [HttpPost]
        public Respuesta Post([FromBody] Conferencista conferencista)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Conferencista creada correctamente.";
                res.Data = control.agregarConferencista(conferencista);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }

        // PUT api/<GestionarConferencistaController>/5
        [HttpPut]
        public Respuesta Put([FromBody] Conferencista conferencista)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Conferencista editada correctamente.";
                res.Data = control.editarConferencista(conferencista);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }

        // DELETE api/<GestionarConferencistaController>/5
        [HttpDelete("{id}")]
        public Respuesta Delete(int id)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Conferencista eliminada correctamente.";
                res.Data = control.eliminarConferencista(id);
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
