using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.GestionarRecusoso;
using Domain.Conferencia;
using Domain.Recurso;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    
    public class GestionarRecursosController : ControllerBase
    {
        CtrlGestionarRecursos control;

        GestionarRecursosController()
        {
           control= new CtrlGestionarRecursos();
        }
        // GET: api/<GestionarRecursosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GestionarRecursosController>/5
        [HttpGet("recursosConferencia/{conferenciaId}/{api_value}")]
        public Respuesta ListarRecursosConferencia(int conferenciaId, string api_value)
        {
            Respuesta res = new Respuesta();
            try
            {
                res.Data = control.ListarRecursosConferencia(conferenciaId,api_value);
                res.mensaje = $"Se listaron los recursos de la conferencia {conferenciaId} exitosamente";
                res.respuesta = true;
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }

        [HttpGet("{api_value}")]
        public Respuesta ListarRecursosDisponibles([FromBody]Conferencia conferencia, string api_value)
        {
            Respuesta res = new Respuesta();
            try
            {
                res.Data = control.ListarRecursosDisponibles(conferencia.HoraInicio,conferencia.Duracion,conferencia.EventoId, api_value);
                res.mensaje = $"Se listaron los recursos disponibles para la conferencia exitosamente";
                res.respuesta = true;
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }

        // POST api/<GestionarRecursosController>
        [HttpPost("{conferenciaId}/{api_value}")]
        public Respuesta AdicionarRecursoConferencia([FromBody] Recurso recurso,int conferenciaId, string api_value)
        {
            Respuesta res = new Respuesta();
            try
            {
                res.Data = control.AdicionarRecusrsosConferencia(recurso.Id, conferenciaId, api_value);
                res.mensaje = $"Recurso adicionado a la conferencia {conferenciaId} exitosamente";
                res.respuesta = true;
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res;
        }

        // PUT api/<GestionarRecursosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GestionarRecursosController>/5
        [HttpDelete("{conferenciaId}/{api_value}")]
        public Respuesta EliminarRecursoConferencia([FromBody] Recurso recurso,int conferenciaId, string api_value)
        {
            Respuesta res = new Respuesta();
            try
            {
                res.Data=control.EliminarRecursoConferencia(recurso.Id, conferenciaId, api_value);
                res.mensaje = $"Recurso eliminado de la conferencia {conferenciaId} exitosamente";
                res.respuesta = true;
            }
            catch(Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }
            return res; 
        }
    }
}
