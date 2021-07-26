using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.CrearUsuario;
using Domain.Usuario;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]    
    public class CrearUsuarioController : ControllerBase
    {
        private CtrlCrearUsuario ctrlUsu;

        public CrearUsuarioController()
        {
            ctrlUsu = new CtrlCrearUsuario();
        }
        // GET: api/<CrearUsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CrearUsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CrearUsuarioController>
        [HttpPost]
        public Respuesta CrearUsuario([FromBody]Usuario value)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.Data = ctrlUsu.CrearUsuario(value);
                res.respuesta = true;
                res.mensaje = "Se creo el usuario correctamente";                
            }
            catch (Exception e)
            {
                res.mensaje = e.Message;
                res.respuesta = false; 
            }
            return res;
        }

        // PUT api/<CrearUsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CrearUsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
