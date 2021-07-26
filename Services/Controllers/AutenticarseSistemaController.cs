using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.ApiKey;
using Application.AutenticarseSistema;
using Domain.Usuario;
using Domain.Common;

namespace Services.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    
    public class AutenticarseSistemaController : ControllerBase
    {
        private CtrlAutenticarseSistema control;
        public AutenticarseSistemaController()
        {
            this.control = new CtrlAutenticarseSistema();
        }

        // GET: api/<AutenticarseSistemaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AutenticarseSistemaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("login")]
        public ApiKey Login([FromBody] Usuario user)
        {
            return control.VerificarUsuario(user.Correo, user.Password);
        }

        // GET api/AutenticarController/resetpassword
        [HttpGet("resetpassword")]
        public Respuesta Reset([FromBody] Usuario user)
        {
            Respuesta salida = new Respuesta();
            try
            {
                bool res = control.RecuperarContraseña(user.Correo);
                salida.respuesta = res;
                if (res)
                {
                    salida.mensaje = "La contraseña se cambio correctamente, " +
                        "por favor revise su correo para obtener su nueva contraseña";
                }
                else
                {
                    salida.mensaje = "No es posible recuperar contraseña";
                }
            }
            catch (Exception)
            {
                salida.mensaje = "No es posible recuperar contraseña";
            }
            return salida;
        }

        // GET api/AutenticarController/resetpassword
        [HttpGet("validarapikey/{api_key}")]
        public Respuesta validate(string api_key)
        {
            Respuesta salida = new Respuesta();
            try
            {
                Usuario res = control.validarApiKey(api_key);
                salida.respuesta = true;
                salida.mensaje = "Api key valida";
                salida.Data = res;
            }
            catch (Exception)
            {
                salida.respuesta = false;
                salida.mensaje = "La Api key es invalida";
            }
            return salida;
        }

        // POST api/<AutenticarseSistemaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AutenticarseSistemaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutenticarseSistemaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
