using Application.TransmitirConferencia;
using Domain.Common;
using Domain.Conferencia;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.TransmitirConferencia
{
    [TestFixture]
    public class TransmitirConferenciaTest
    {
        public TransmitirConferenciaTest()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
        }

        [Test]
        public void TransmitirConferenciaValida()
        {
            CtrlTransmitirConferencia control = new CtrlTransmitirConferencia();
            int id = 2;
            string url = @"https://www.youtube.com/watch?v=5NPBIwQyPWE&ab_channel=AvrilLavigneVEVO";
            Assert.That((control.AsignarUrl(url,id) is Conferencia), 
                Is.EqualTo(true),
                "Se asigno la url a la conferencia correctamente.");
        }

        [Test]
        public void TransmitirConferenciaInvalida()
        {
            CtrlTransmitirConferencia control = new CtrlTransmitirConferencia();
            int id = 35;
            string url = @"https://www.youtube.com/watch?v=5NPBIwQyPWE&ab_channel=AvrilLavigneVEVO";
            Assert.Throws<ConferenciaNoEncontradaException>(() => control.AsignarUrl(url, id),
                "La conferencia no existe");
        }

        [Test]
        public void TransmitirConferenciaValidaUrlInvalida()
        {
            CtrlTransmitirConferencia control = new CtrlTransmitirConferencia();
            int id = 2;
            string url = "";
            Assert.Throws<ValorIncorrectoException>(() => control.AsignarUrl(url, id),
                "La url es incorecta");
        }


    }
}
