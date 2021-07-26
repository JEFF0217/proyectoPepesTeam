using Application.GestionarEvento;
using Domain.Common;
using Domain.Evento;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.GestionEvento
{
    [TestFixture]
    class GestionEventoObtenerEventoTest
    {
        public GestionEventoObtenerEventoTest()
        {

            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
            ConfigurationManager.AppSettings["url_api"] = "https://localhost:44334";

        }
        [Test]

        public void getEventoValido()
        {
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlGestionarEvento control = new CtrlGestionarEvento();
            Assert.That(control.ObtenerEvento(1,api_value), !Is.EqualTo(null), "MELO");
        }
        [Test]
        public void getEventoInValidoNoExiste()
        {
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlGestionarEvento control = new CtrlGestionarEvento();
            Assert.Throws<EventoNoEncontradoException>(() => control.ObtenerEvento(300, api_value));
        }
        [Test]
        public void getEventoInValidoDatosFaltanDatos()
        {
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlGestionarEvento control = new CtrlGestionarEvento();
            Assert.Throws<ValorIncorrectoException>(() => control.ObtenerEvento(0, api_value));
        }
    }
}
