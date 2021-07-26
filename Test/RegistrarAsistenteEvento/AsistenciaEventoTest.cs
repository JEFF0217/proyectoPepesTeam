using Application.RegistrarEntradaEvento;
using Domain.Common;
using Domain.Evento;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.RegistrarAsistenteEvento
{
    [TestFixture]
    class AsistenciaEventoTest
    {
        public AsistenciaEventoTest()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
            ConfigurationManager.AppSettings["url_api"] = "https://localhost:44334";
        }

        [Test]
        public void registrarEntradaPresencialValido()
        {
            string nombre = "Asistente3";
            string identificacion = "106";
            int eventoId = 1;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaEvento control = new CtrlRegistrarEntradaEvento();
            Assert.That(!control.registrarEntradaPresencial(nombre, identificacion, eventoId, api_value).Equals(""),Is.EqualTo(true),"meloooo");

        }
        [Test]
        public void registrarEntradaPresencialInValidoYaExiste()
        {
            string nombre = "Asistente2";
            string identificacion = "67";
            int eventoId = 1;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaEvento control = new CtrlRegistrarEntradaEvento();
            Assert.Throws<AsistenciaEventoException>(  () => control.registrarEntradaPresencial(nombre, identificacion, eventoId, api_value));
               

        }
        [Test]
        public void registrarEntradaPresencialInValidoNoExisteEvento()
        {
            string nombre = "Asistente3";
            string identificacion = "63";
            int eventoId = 0;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaEvento control = new CtrlRegistrarEntradaEvento();
            Assert.Throws<ValorIncorrectoException>(() => control.registrarEntradaPresencial(nombre, identificacion, eventoId, api_value));


        }
        [Test]
        public void registrarEntradaVirtualValido()
        {
            
            string identificacion = "70";
            int eventoId = 1;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaEvento control = new CtrlRegistrarEntradaEvento();
            Assert.That(!control.registrarEntradaVirtual(identificacion,eventoId,api_value), Is.EqualTo(false), "meloooo");

        }
        [Test]
        public void registrarEntradaVirtualInValidoYaExiste()
        {
           
            string identificacion = "65";
            int eventoId = 1;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaEvento control = new CtrlRegistrarEntradaEvento();
            Assert.Throws<AsistenciaEventoException>(() => control.registrarEntradaVirtual( identificacion, eventoId, api_value));


        }
        [Test]
        public void registrarEntradaVirtualInValidoNoExisteEvento()
        {
           
            string identificacion = "63";
            int eventoId = 0;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlRegistrarEntradaEvento control = new CtrlRegistrarEntradaEvento();
            Assert.Throws<ValorIncorrectoException>(() => control.registrarEntradaVirtual( identificacion, eventoId, api_value));


        }
    }
}
