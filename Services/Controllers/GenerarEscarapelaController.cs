using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.GenerarEscarapela;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GenerarEscarapelaController : ControllerBase
    {
        CtlrGenerarEscarapela control;
        public GenerarEscarapelaController()
        {
            control = new CtlrGenerarEscarapela();
        }
        // GET: api/<GenerarEscarapelaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GenerarEscarapelaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GenerarEscarapelaController>
        [HttpGet("{eventoId}/{nombre}/{tipo}/{identificacion}")]
        public Respuesta genearEsaWea(int eventoId, string nombre, string tipo, string identificacion)
        {
            Respuesta res = new Respuesta();

            try
            {                
                res.respuesta = true;
                res.mensaje = control.GenerarEscarapela(eventoId, nombre, tipo, identificacion);
            }
            catch (Exception e)
            {
                res.mensaje = e.Message;
                res.respuesta = false;
            }
            return res;
        }

        // PUT api/<GenerarEscarapelaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GenerarEscarapelaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
