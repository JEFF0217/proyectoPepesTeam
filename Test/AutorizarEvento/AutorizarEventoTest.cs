using Application.AutorizarEvento;
using Domain;
using Domain.Common;
using Domain.Evento;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.AutorizarEvento
{
    [TestFixture]
    public class AutorizarEventoTest
    {
        public AutorizarEventoTest()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
        }

        [Test]
        public void CambiarEstadoDeEventoValido()
        {
            CtrlAutorizarEvento control = new CtrlAutorizarEvento();
            int eventoId = 1;
            EstadoEvento estado = EstadoEvento.Aceptado;
            Assert.That(control.CambiarEstado(eventoId,estado), Is.EqualTo(true),
                "Cambio de estado del evento ejecutado correctamente");
        }

        [Test]
        public void CambiarEstadoDeEventoNoExiste()
        {
            CtrlAutorizarEvento control = new CtrlAutorizarEvento();
            int eventoId = 23;
            EstadoEvento estado = EstadoEvento.Pendiente;
            Assert.Throws<EventoNoEncontradoException>(() => control.CambiarEstado(eventoId, estado),
                "No se logró cambiar el evento no existe");
        }

        [Test]
        public void CambiarEstadoDeEventoExisteEstadoInvalido()
        {
            CtrlAutorizarEvento control = new CtrlAutorizarEvento();
            int eventoId = 23;
            EstadoEvento estado = (EstadoEvento)5;
            Assert.Throws<ValorIncorrectoException>(() => control.CambiarEstado(eventoId, estado),
                "No se logró cambiar el evento no existe");
        }

    }
}
