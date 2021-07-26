using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.PreinscribirseEvento;
using Domain.Asistente;
using Domain.Inscripcion;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PreInscribirseEventoController : ControllerBase
    {

        private CtrlPreinscribirseEvento control;

        public PreInscribirseEventoController()
        {
            control = new CtrlPreinscribirseEvento();
        }








        // GET: api/<PreInscribirseEventoController>
        [HttpGet("asistente/{id}")]
        public Respuesta buscarAsistente(int Id)
        {
            Respuesta res = new Respuesta();
            try
            {
                res.respuesta = true;
                res.mensaje = "Listado obtenido correctamente.";
                res.Data = control.buscarAsistente(Id);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }

            return res;
            ;
        }

        // GET api/<PreInscribirseEventoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }





        // POST api/<PreInscribirseEventoController>
        [HttpPost("{idEvento}")]
        public Respuesta Post(int idEvento,[FromBody] Asistente asistente)
        {
            Respuesta res = new Respuesta();
            try
            {
                res.respuesta = true;
                res.mensaje = " Se preinscribio correctamente correctamente.";
                res.Data = control.agregarInscripcion(asistente,idEvento);
                
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }

            return res;
        }

        // PUT api/<PreInscribirseEventoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PreInscribirseEventoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
