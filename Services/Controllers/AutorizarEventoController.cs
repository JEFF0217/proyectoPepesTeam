using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.AutorizarEvento;
using Domain;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorizarEventoController : ControllerBase
    {
        CtrlAutorizarEvento control;
        public AutorizarEventoController()
        {
            this.control = new CtrlAutorizarEvento();
        }

        [HttpPost("{eventoId}/{estado}")]
        public Respuesta CambiarEstadoEvento(int eventoId,EstadoEvento estado)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Se cambio el estado del evento correctamente.";
                res.Data = control.CambiarEstado(eventoId,estado);
            }
            catch (Exception e)
            {
                res.mensaje = e.Message;
            }
            return res;
        }
    }
}
