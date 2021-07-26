using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.TransmitirConferencia;
using Domain.Common;
using Domain.Conferencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransmitirConferenciaController : ControllerBase
    {
        CtrlTransmitirConferencia control = new CtrlTransmitirConferencia();

        [HttpPost]
        public Respuesta TransmitirConferencia([FromBody] Conferencia conferencia)
        {
            Respuesta res = new Respuesta();

            try
            {
                res.respuesta = true;
                res.mensaje = "Url asignada correctamente.";
                res.Data = control.AsignarUrl(conferencia.Url, conferencia.Id);
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
