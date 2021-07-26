using Application.CrearUsuario;
using Domain.Usuario;
using NUnit.Framework;
using System.Configuration;

namespace Test.CrearUsuario
{
    [TestFixture]
    class CrearUsuarioTest
    {
        public CrearUsuarioTest()
        {
            ConfigurationManager.AppSettings["repository"] = "json";
            ConfigurationManager.AppSettings["main"] = "test";
        }
        [Test]
        public void CrearUsuarioConCorreoValido()
        {
            CtrlCrearUsuario control = new CtrlCrearUsuario();
            Usuario user = new Usuario
            {
                Nombre = "David",
                Apellido = "Roldán",
                Correo = "derolan98@gmail.com",
                Identificacion = "12345665",
                Password = "admin"
            };
            Assert.That(control.CrearUsuario(user), !Is.EqualTo(null), "Usuario creado con exito");
        }

        [Test]
        public void CrearUsuarioConCorreoExistente()
        {
            CtrlCrearUsuario control = new CtrlCrearUsuario();
            Usuario user = new Usuario
            {
                Nombre = "David",
                Apellido = "Roldán",
                Correo = "npi1@gmail.com",
                Identificacion = "12345665",
                Password = "admin"
            };
            Assert.Throws<CorreoEncontradoException>(() => control.CrearUsuario(user));
        }

        [Test]
        public void CrearUsuarioConIdentificacionExistente()
        {
            CtrlCrearUsuario control = new CtrlCrearUsuario();
            Usuario user = new Usuario
            {
                Nombre = "David",
                Apellido = "Roldán",
                Correo = "npi9999@gmail.com",
                Identificacion = "70",
                Password = "admin"
            };
            Assert.Throws<CorreoEncontradoException>(() => control.CrearUsuario(user));
        }

    }
}
