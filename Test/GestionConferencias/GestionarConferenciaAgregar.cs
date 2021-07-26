using Application.GestionarConferencia;
using Domain.Conferencia;
using Domain.Evento;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.GestionConferencias
{
    [TestFixture]
    public class GestionarConferenciaAgregar
    {
        public GestionarConferenciaAgregar()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
            ConfigurationManager.AppSettings["url_api"] = "https://localhost:44334";

        }

        [Test]
        public void agregarConferenciaValida()
        {
            CtrlGestionarConferencia control = new CtrlGestionarConferencia();
            Conferencia conferencia = new Conferencia
            {
                Nombre = "Lo más sano",
                Descripcion = "Comer bien y hacer ejercicios regularmente te ayudará a mantener tu peso y reducir los riegos de contraer alguna enfermedad. El ejercio regular y una dieta saludable pueden traer muchos beneficios, incluyendo más energía, felicidad, salud y hasta una vida más larga.",
                HoraInicio = DateTime.Now,
                Duracion = 12,
                Archivo = "unarchivo.jpg",
                EventoId = 1,
                AulaId = "3da",
            };

            string api_value = "ZMgfl5dL2UKKEAFfbTaaEA";

            Assert.That((control.agregarConferencia(conferencia, api_value) is Conferencia),
                   Is.EqualTo(true),
                   "Se agrego correctamente la conferencia.");

        }

        [Test]
        public void agregarConferenciaValidaEventoNoExiste()
        {
            CtrlGestionarConferencia control = new CtrlGestionarConferencia();
            Conferencia conferencia = new Conferencia
            {
                Nombre = "Lo más sano",
                Descripcion = "Comer bien y hacer ejercicios regularmente te ayudará a mantener tu peso y reducir los riegos de contraer alguna enfermedad. El ejercio regular y una dieta saludable pueden traer muchos beneficios, incluyendo más energía, felicidad, salud y hasta una vida más larga.",
                HoraInicio = DateTime.Now,
                Duracion = 12,
                Archivo = "unarchivo.jpg",
                EventoId = 23,
                AulaId = "3da",
            };

            string api_value = "ZMgfl5dL2UKKEAFfbTaaEA";


            Assert.Throws<EventoNoEncontradoException>(() => control.agregarConferencia(conferencia, api_value),
               "El evento no existe");

        }

    }

}
