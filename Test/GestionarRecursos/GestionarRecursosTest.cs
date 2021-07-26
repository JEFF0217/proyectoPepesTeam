using Application.GestionarRecusoso;
using Domain.Conferencia;
using Domain.Evento;
using Domain.Recurso;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.GestionarRecursos
{
    [TestFixture]
    class GestionarRecursosTest
    {
        public GestionarRecursosTest()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
            ConfigurationManager.AppSettings["url_api"] = "https://localhost:44334";
        }

        [Test]
        public void ListarRecusrsosDisponiblesValido()
        {
            CtrlGestionarRecursos control = new CtrlGestionarRecursos();
            DateTime inicio = new DateTime(2015, 01, 01, 08, 00, 00);
            int duracion = 15;
            int eventoId = 1;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            Assert.That(control.ListarRecursosDisponibles(inicio, duracion, eventoId, api_value), !Is.EqualTo(null), "Recursos disponibles listados con exito");
        }
        [Test]
        public void ListarRecusrsosDisponiblesEventoNoExiste()
        {
            CtrlGestionarRecursos control = new CtrlGestionarRecursos();
            DateTime inicio = new DateTime(2015, 01, 01, 08, 00, 00);
            int duracion = 15;
            int eventoId = 100;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            Assert.Throws<EventoNoEncontradoException>(() => control.ListarRecursosDisponibles(inicio, duracion, eventoId, api_value));
        }

        [Test]
        public void ListarRecursosConferencia()
        {
            CtrlGestionarRecursos control = new CtrlGestionarRecursos();
            int conferenciaId = 6;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            Assert.That(control.ListarRecursosConferencia(conferenciaId, api_value), !Is.EqualTo(null),
                "Recursos disponibles listados con exito");
        }

        [Test]
        public void ListarRecursosConferenciaNoExistente()
        {
            CtrlGestionarRecursos control = new CtrlGestionarRecursos();
            int conferenciaId = 100;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            Assert.Throws<ConferenciaNoEncontradaException>(() => control.ListarRecursosConferencia(conferenciaId, api_value));
        }

        [Test]
        public void AgregarRecursoExistente()
        {
            CtrlGestionarRecursos control = new CtrlGestionarRecursos();
            int recursoId = 999;
            int conferenciaId = 2;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            Assert.That(control.AdicionarRecusrsosConferencia(recursoId, conferenciaId, api_value),
                !Is.EqualTo(null), $"Recursos acidionado a la conferencia {conferenciaId}");
        }

        [Test]
        public void AgregarRecursoNoExistente()
        {
            CtrlGestionarRecursos control = new CtrlGestionarRecursos();
            int recursoId = 998;
            int conferenciaId = 2;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            Assert.Throws<RecursoNoEncontradoException>(() => control.AdicionarRecusrsosConferencia(recursoId, conferenciaId, api_value));
        }

        [Test]
        public void EliminarRecursoExistente()
        {
            CtrlGestionarRecursos control = new CtrlGestionarRecursos();
            int recursoId = 999;
            int conferenciaId = 7;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            Assert.That(control.EliminarRecursoConferencia(recursoId, conferenciaId, api_value),
                !Is.EqualTo(null), $"Recursos acidionado a la conferencia {conferenciaId}");
        }

        [Test]
        public void ElminiarRecursoNoEncontrado()
        {
            CtrlGestionarRecursos control = new CtrlGestionarRecursos();
            int recursoId = 998;
            int conferenciaId = 7;
            string api_value = "EKolseLnUaypYTdDQrwnQ";
            Assert.Throws<RecursoNoEncontradoException>(() => control.AdicionarRecusrsosConferencia(recursoId, conferenciaId, api_value));
        }
    }
}


