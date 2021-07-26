using Application.AutenticarseSistema;
using Domain.ApiKey;
using Domain.Usuario;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test.AtenticarseSistemaTest
{
    [TestFixture]
    class AutenticarseSistemaTest
    {
        public AutenticarseSistemaTest()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
        }
        [Test]
        public void CorreoContraseñaValidos()
        {   
            CtrlAutenticarseSistema control = new CtrlAutenticarseSistema();
            string contraseña ="123456789" ; 
            string correo ="juacagiri@gmail.com";            
            Assert.That((control.VerificarUsuario(correo,contraseña) is ApiKey), Is.EqualTo(true), "Usuario logeado con exito");
        }
        [Test]
        public void CorreoInvalido()
        {
            CtrlAutenticarseSistema control = new CtrlAutenticarseSistema();
            string contraseña = "123456789";
            string correo = "juacag@gmail.com";
            Assert.Throws<UsuarioNoEncontradoException>(() => control.VerificarUsuario(correo,contraseña));
        }
        [Test]
        public void ContraseñaInvalida()
        {
            CtrlAutenticarseSistema control = new CtrlAutenticarseSistema();
            string contraseña = "12345678";
            string correo = "juacagiri@gmail.com";
            Assert.Throws<UsuarioNoEncontradoException>(() => control.VerificarUsuario(correo, contraseña));
        }
    }
}
