using Application.GestionarConferencia;
using Domain.Common;
using Domain.Conferencia;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.GestionConferencias
{
    [TestFixture]
    public class GestionarConferenciaEliminar
    {
        public GestionarConferenciaEliminar()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
        }


        [Test]
        public void EliminarConferenciaValida()
        {
            CtrlGestionarConferencia control = new CtrlGestionarConferencia();
            int conferenciaId = 9;
            Assert.That(control.eliminarConferencia(conferenciaId),
               Is.EqualTo(true),
               "Se elimino la conferencia correctamente.");
        }

        [Test]
        public void EliminarConferenciaIdInvalido()
        {
            int conferenciaId = -1;
            CtrlGestionarConferencia control = new CtrlGestionarConferencia();
            Assert.Throws<ValorIncorrectoException>(() => control.eliminarConferencia(conferenciaId),
               "Valor de id de conferencia invalido");
        }

        [Test]
        public void EliminarConferenciaNoExiste()
        {
            int conferenciaId = 23;
            CtrlGestionarConferencia control = new CtrlGestionarConferencia();
            Assert.Throws<ConferenciaNoEncontradaException>(() => control.eliminarConferencia(conferenciaId),
               "Valor de id de conferencia invalido");
        }

    }
}
