using Application.GestionarAulas;
using Domain.Aula;
using Domain.Common;
using Domain.Evento;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.GestionarAulas
{
    [TestFixture]
    class GestionarAulasTest
    {
       
        public GestionarAulasTest() {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
            ConfigurationManager.AppSettings["url_api"] = "https://localhost:44334";
        }


        //-----------------------------------pruebas para agregar aula-----------------------------------------
        [Test]
        public void agregarAulaEventoValido()
        {
            CtrlGestionarAula control = new CtrlGestionarAula();
            Aula aula = new Aula
            {
                Id = "CU102",
                Capacidad = 13,
                EventoId = 1
            };
            Assert.That(control.agregarAula(aula), !Is.EqualTo(null), "Aula creado con exito");
        }
        [Test]
        public void agregarAulaEventinvalido()
        {
            CtrlGestionarAula control = new CtrlGestionarAula();
            Aula aula = new Aula
            {
                Id = "CU110",
                Capacidad = 13,
                EventoId = 200
            };
            Assert.Throws<EventoNoEncontradoException>(() => control.agregarAula(aula));
        }
        [Test]
        public void agregarAulaDuplicada()
        {
            CtrlGestionarAula control = new CtrlGestionarAula();
            Aula aula = new Aula
            {
                Id = "CU110",
                Capacidad = 14,
                EventoId = 2
            };
            Assert.Throws<AulaDuplicadaException>(() => control.agregarAula(aula));
        }

        //-----------------------------------pruebas para editar aula-----------------------------------------
        [Test]
        public void EditarAulacapacidadValidad()
        {
            CtrlGestionarAula control = new CtrlGestionarAula();
            Aula aula = new Aula
            {
                Id = "CU101",
                Capacidad = 16,
                EventoId = 1
            };
            Assert.That(control.editarAula(aula), !Is.EqualTo(null), "Aula editada correctamente");
        }
        [Test]
        public void EditarAulacapacidadInvalidad()
        {
            CtrlGestionarAula control = new CtrlGestionarAula();
            Aula aula = new Aula
            {
                Id = "CU101",
                Capacidad = -5,
                EventoId = 1
            };
            Assert.Throws<ValorIncorrectoException>(() => control.editarAula(aula));
        }
        //-----------------------------------pruebas para Elimiar aula-----------------------------------------
        [Test]
        public void ELiminarAulaExistente()
        {
            CtrlGestionarAula control = new CtrlGestionarAula();
            String id = "CU102";
            int eventoId = 1;
           
            Assert.That(control.eliminarAula(id,eventoId), !Is.EqualTo(null), "Aula eliminada correctamente");
        }


        [Test]
        public void ELiminarAulaInexistente()
        {
            CtrlGestionarAula control = new CtrlGestionarAula();
            String id = "CU200";
            int eventoId = 1;

            Assert.Throws<AulaNoEncontradaException>(() => control.eliminarAula(id, eventoId));
        }






    }
}
