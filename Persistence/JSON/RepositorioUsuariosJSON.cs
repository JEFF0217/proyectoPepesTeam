using Domain.Usuario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Configuration;
using System.Text.Json;

namespace Persistence.JSON
{
    class RepositorioUsuariosJSON : IRepositorioUsuario
    {
        private String path = @"..\CoreAMTest\repos\usuarios.json";

        public RepositorioUsuariosJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\usuarios.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\usuarios.json";
            }
        }


        private List<Usuario> leerUsuarios()
        {
            List<Usuario> usuarios;
            String jsonString = "";
            try
            {
                jsonString = File.ReadAllText(path);
                usuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(jsonString);
                return usuarios;
            }
#pragma warning disable CS0168 // La variable 'e' se ha declarado pero nunca se usa
            catch (JsonException e)
#pragma warning restore CS0168 // La variable 'e' se ha declarado pero nunca se usa
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
#pragma warning disable CS0168 // La variable 'e' se ha declarado pero nunca se usa
            catch (Exception e)
#pragma warning restore CS0168 // La variable 'e' se ha declarado pero nunca se usa
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de usuarios.");
            }
        }

        public bool CrearUsuario(Usuario user)
        {
            List<Usuario> usuarios = leerUsuarios();
            int id = 1;
            if (usuarios.Count > 0)
            {
                Usuario aux = usuarios[usuarios.Count - 1];
                id = aux.Id + 1;
            }
            user.Id = id;
            usuarios.Add(user);
            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(usuarios,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un problema al guardar el usuario en el repositorio.");

            }
        }

        public Usuario GetUsuario(int Id)
        {
            Usuario usuario = this.leerUsuarios().FirstOrDefault(u => u.Id == Id);
            if (usuario == null)
            {
                throw new UsuarioNoEncontradoException("No se encontro un usuario con este id");
            }
            return usuario;
        }

        public Usuario BuscarUsuario(string correo, string identificacion)
        {

            Usuario usuario = this.leerUsuarios().FirstOrDefault(u => u.Correo == correo || u.Identificacion == identificacion);

            if (usuario == null)
            {
                throw new UsuarioNoEncontradoException("No se encontro un usuario con este correo o Identificacion");

            }
            return usuario;

        }

        public bool EnviarCorreo(Usuario recuperar, string correo)
        {
            string contra = CrearContraseñaAleatoria();
            CambiarContraseña(recuperar, contra);
            //return "aca se manda un correo";
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(correo);
            msg.Subject = "recuperar contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = "Su nueva contraseña es :" + contra;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new System.Net.Mail.MailAddress("cuentaproyectop3@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            cliente.Credentials = new System.Net.NetworkCredential("cuentaproyectop3@gmail.com", "prog123456");

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";//mail.dominio.com
            try
            {
                cliente.Send(msg);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo enviar el correo");
            }
            return true;
        }


        public bool CambiarContraseña(Usuario userNew, string nuevaContra)
        {
            List<Usuario> usuarios = leerUsuarios();
            Usuario usuarioOld;
            usuarioOld = usuarios.Find(c => c.Id == userNew.Id);

            userNew.Password = nuevaContra;

            try
            {
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(usuarios, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error al actualizar la información en el repositorio usuario.");
            }

            return true;
        }

        public string CrearContraseñaAleatoria()
        {
            int longitud = 7;
            Guid miGuid = Guid.NewGuid();
            string token = miGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);
            return token;
        }


    }
}

