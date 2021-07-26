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
    class GestionEventoEliminarTest
    {

       
        public GestionEventoEliminarTest()
        {

            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
            ConfigurationManager.AppSettings["url_api"] = "https://localhost:44334";

        }
        [Test]
        public void elimnarEventoValido() 
        {
           
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlGestionarEvento control = new CtrlGestionarEvento();
            Assert.That(control.eliminarEvento(4,api_value), Is.EqualTo(true), "MELO");

        }
        [Test]
        public void elimnarEventoValidoNoExiste()
        {

            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlGestionarEvento control = new CtrlGestionarEvento();
            Assert.Throws<EventoNoEncontradoException>(() => control.eliminarEvento(4, api_value));

        }
        [Test]
        public void elimnarEventoINValidoDatosFaltan()
        {

            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlGestionarEvento control = new CtrlGestionarEvento();
            Assert.Throws<ValorIncorrectoException>(() => control.eliminarEvento(0, api_value));

        }
    }
}
