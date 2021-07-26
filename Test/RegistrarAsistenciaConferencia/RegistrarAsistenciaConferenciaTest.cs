using Application.RegistrarEntradaConferenciaPresencial;
using Domain.Common;
using Domain.Conferencia;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.RegistrarAsistenciaConferencia
{

    [TestFixture]
    class RegistrarAsistenciaConferenciaTest
    {
        public RegistrarAsistenciaConferenciaTest()
        {

            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
            ConfigurationManager.AppSettings["url_api"] = "https://localhost:44334";

        }
        [Test]
        public void registrarEntradaPresencialValido()
        {
            int conferenciaId = 2;
            
            string identificacion = "67";
            int eventoId = 1;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaConferencia control = new CtrlRegistrarEntradaConferencia();
            Assert.That(control.registrarEntradaPresencial(conferenciaId, identificacion, eventoId, api_value), Is.EqualTo(true), "meloooo");

        }
        [Test]
        public void registrarEntradaPresencialInValidoYaExiste()
        {
            int conferenciaId = 2;

            string identificacion = "63";
            int eventoId = 1;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaConferencia control = new CtrlRegistrarEntradaConferencia();
            Assert.Throws<AsistenciaConferenciaException>(() => control.registrarEntradaPresencial(conferenciaId, identificacion, eventoId, api_value));


        }
        [Test]
        public void registrarEntradaPresencialInValidoNoExisteEvento()
        {
            int conferenciaId = 2;

            string identificacion = "69";
            int eventoId = 0;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaConferencia control = new CtrlRegistrarEntradaConferencia();
            Assert.Throws<ValorIncorrectoException>(() => control.registrarEntradaPresencial(conferenciaId, identificacion, eventoId, api_value));


        }
        [Test]
        public void registrarEntradaVirtualValido()
        {
            int conferenciaId = 2;

            string identificacion = "61";
            int eventoId = 1;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaConferencia control = new CtrlRegistrarEntradaConferencia();
            Assert.That(!control.registrarEntradaVirtual(conferenciaId,identificacion, eventoId, api_value).Equals(""), Is.EqualTo(true), "meloooo");

        }
        [Test]
        public void registrarEntradaVirtualInValidoYaExiste()
        {
            int conferenciaId = 2;

            string identificacion = "65";
            int eventoId = 1;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaConferencia control = new CtrlRegistrarEntradaConferencia();
            Assert.Throws<AsistenciaConferenciaException>(() => control.registrarEntradaVirtual(conferenciaId,identificacion, eventoId, api_value));


        }
        [Test]
        public void registrarEntradaVirtualInValidoNoExisteEvento()
        {

            int conferenciaId = 2;

            string identificacion = "65";
            int eventoId = 0;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaConferencia control = new CtrlRegistrarEntradaConferencia();
            Assert.Throws<ValorIncorrectoException>(() => control.registrarEntradaVirtual(conferenciaId ,identificacion, eventoId, api_value));


        }
    }
}
