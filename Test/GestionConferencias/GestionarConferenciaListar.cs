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
    public class GestionarConferenciaListar
    {
        public GestionarConferenciaListar()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
        }

        [Test]
        public void ListarConferenciasEventoValido()
        {
            int eventoId = 1;
            CtrlGestionarConferencia control = new CtrlGestionarConferencia();
            Assert.That((control.listarConferencias(eventoId) is List<Conferencia>),
               Is.EqualTo(true),
               "Se obtuvo la lista de conferencias del evento con id 1.");
        }

        [Test]
        public void ListarConferenciasEventoNoExiste()
        {
            int eventoId = 23;
            CtrlGestionarConferencia control = new CtrlGestionarConferencia();
            Assert.Throws<EventoNoEncontradoException>(() => control.listarConferencias(eventoId),
               "Valor del evento id Invalido");
        }
    }
}
