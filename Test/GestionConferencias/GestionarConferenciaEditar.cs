using Application.GestionarConferencia;
using Domain.Conferencia;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.GestionConferencias
{
    [TestFixture]
    public class GestionarConferenciaEditar
    {
        public GestionarConferenciaEditar()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
        }

        [Test]
        public void agregarConferenciaExiste()
        {
            CtrlGestionarConferencia control = new CtrlGestionarConferencia();
            Conferencia conferencia = new Conferencia
            {
                Id = 2,
                Nombre = "El nuevo nombre",
                Descripcion = "Comer bien y hacer ejercicios regularmente te ayudará a mantener tu peso y reducir los riegos de contraer alguna enfermedad. El ejercio regular y una dieta saludable pueden traer muchos beneficios, incluyendo más energía, felicidad, salud y hasta una vida más larga.",
                HoraInicio = DateTime.Now,
                Duracion = 12,
                Archivo = "unarchivo.jpg",
                EventoId = 1,
                AulaId = "3da",
            };

            Assert.That((control.editarConferencia(conferencia) is Conferencia),
                   Is.EqualTo(true),
                   "Se edito correctamente la conferencia.");

        }

        [Test]
        public void conferenciaConferenciaNoExiste()
        {
            CtrlGestionarConferencia control = new CtrlGestionarConferencia();
            Conferencia conferencia = new Conferencia
            {
                Id= 23,
                Nombre = "EL nuevo nombre",
                Descripcion = "Comer bien y hacer ejercicios regularmente te ayudará a mantener tu peso y reducir los riegos de contraer alguna enfermedad. El ejercio regular y una dieta saludable pueden traer muchos beneficios, incluyendo más energía, felicidad, salud y hasta una vida más larga.",
                HoraInicio = DateTime.Now,
                Duracion = 12,
                Archivo = "unarchivo.jpg",
                EventoId = 1,
                AulaId = "3da",
            };

            Assert.Throws<ConferenciaNoEncontradaException>(() => control.editarConferencia(conferencia),
               "El evento no existe");

        }

    }
}
