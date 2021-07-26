using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.GestionarAulas;
using Domain.Aula;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestionAulaController : ControllerBase
    {
        private CtrlGestionarAula control;

        public GestionAulaController()
        {
            control = new CtrlGestionarAula();
        }


        // GET: api/<GestionAulaController>
        [HttpGet("aulas/{eventoId}")]
        public Respuesta GetAulas(int EventoId)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Listado obtenido correctamente.";
                res.Data = control.ListarAulas(EventoId);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }


            return res;
        }




        // GET api/<GestionAulaController>/5
        [HttpGet("aula/{id}/{eventoId}")]
        public Respuesta GetAula(string id,int EventoId)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Aula obtenida correctamente";
                res.Data = control.obtenerAula(id,EventoId);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }

            return res;
        }





        // POST api/<GestionAulaController>
        [HttpPost]
        public Respuesta agregarAula([FromBody] Aula aula)
        {
            Respuesta res = new Respuesta();
            try
            {
                res.respuesta = true;
                res.mensaje = "Aula creada correctamente";
                res.Data = control.agregarAula(aula);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }

            return res;

        }



        // PUT api/<GestionAulaController>/5
        [HttpPut]
        public Respuesta editarAula([FromBody]Aula aula)
        {
            Respuesta res = new Respuesta();
            try
            {
                res.respuesta = true;
                res.mensaje = "Aula editada correctamente";
                res.Data = control.editarAula(aula);
            }
            catch (Exception e)
            {
                res.respuesta = false;
                res.mensaje = e.Message;
            }


            return res;

        }

        // DELETE api/<GestionAulaController>/5
        [HttpDelete("aula/{id}/{eventoId}")]
        public Respuesta Delete(string id,int eventoId)
        {
            Respuesta res = new Respuesta();
            try
            {
                res.respuesta = true;
                res.mensaje = "Aula eliminada correctamente";
                res.Data = control.eliminarAula(id,eventoId);
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
