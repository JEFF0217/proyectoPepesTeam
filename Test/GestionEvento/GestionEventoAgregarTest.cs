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
    class GestionEventoAgregarTest
    {
        public GestionEventoAgregarTest()
        {

            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
            ConfigurationManager.AppSettings["url_api"] = "https://localhost:44334";

        }
        [Test]
        public void agregarEventoValido()
        {
            Evento evento = new Evento
            {
                Ciudad = "Maniz",
                Descripcion = "estamos melos",
                Estado = 0,
                Fecha = new DateTime(2015, 01, 01, 08, 00, 00),
                Id =7,
                Lugar = "mika",
                MaximoAsistentes = 50,
                MinimoAsistentes = 15,
                Nombre = "estamos",
                Valor = 20000.0
            };
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlGestionarEvento control = new CtrlGestionarEvento();
            Assert.That(control.agregarEvento(evento, api_value), !Is.EqualTo(null), "MELO");
            control.eliminarEvento(6,api_value);
        }

        [Test]
        public void agregarEventoInValidoFaltaDatos()
        {
            Evento evento = new Evento
            {
                Ciudad = "Manizales",
                Descripcion = "",
                Estado = 0,
                Fecha = new DateTime(2015, 01, 01, 08, 00, 00),
                Id = -5,
                Lugar = "mika",
                MaximoAsistentes = 50,
                MinimoAsistentes = 15,
                Nombre = "estamos melos",
                Valor = 20000.0
            };
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlGestionarEvento control = new CtrlGestionarEvento();
            Assert.Throws<ValorIncorrectoException>(() => control.agregarEvento(evento, api_value));
        }
        [Test]
        public void agregarEventoInValidoYaExiste()
        {
            Evento evento = new Evento
            {
                Ciudad = "Manizales",
                Descripcion = "estamos melos",
                Estado = 0,
                Fecha = new DateTime(2015, 01, 01, 08, 00, 00),
                Id = 300,
                Lugar = "mika",
                MaximoAsistentes = 50,
                MinimoAsistentes = 15,
                Nombre = "estamos melos",
                Valor = 20000.0
            };
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            CtrlGestionarEvento control = new CtrlGestionarEvento();
            Assert.Throws<EventoYaExisteException>(() => control.agregarEvento(evento, api_value));
        }
    }
}
