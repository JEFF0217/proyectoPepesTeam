using Domain.Usuario;
using Domain.ApiKey;
using Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Application.AutenticarseSistema
{
    public class CtrlAutenticarseSistema
    {
        IRepositorioUsuario repUsu;
        IRepositorioApiKey repKey;

        public CtrlAutenticarseSistema()
        {
            repUsu = FabricaRepositorioUsuarios.CrearRepositorioUsuarios();
            repKey = FabricaRepositorioApiKey.CrearRepositorioApiKey(); 
        }

        public Usuario BuscarUsuario(string correo,string identificacion="")
        {
            return repUsu.BuscarUsuario(correo,identificacion);
        }

        public ApiKey VerificarUsuario(string correo,string contraseña)
        {
            Usuario user = BuscarUsuario(correo,""); 
            if (user != null)
            {
                string codificada = codificarContraseña(contraseña);

                if (codificada == user.Password)
                {
                    ApiKey api_key = repKey.crear(user.Id);
                    return api_key;
                }
                else
                {
                    throw new UsuarioNoEncontradoException("La contraseña del usuario es incorrecta.");
                }

            }
            else
            {
                throw new UsuarioNoEncontradoException($"No se encontro un usuario con el correo: {correo}.");
            }
        }

        public Usuario BuscarUsuarioPorId(int usuarioId)
        {
            return repUsu.GetUsuario(usuarioId);
        }

        public Usuario validarApiKey(string value)
        {
            ApiKey api_key = repKey.consultar(value);

            if (api_key != null)
            {
                Usuario user = BuscarUsuarioPorId(api_key.usuarioId);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new UsuarioNoEncontradoException("No se encontro el usuario.");
                }

            }
            else
            {
                throw new ApiKeyNoEncontradaException("La api key ingresada es invalida.");
            }
        }
                

        public bool RecuperarContraseña(string correo)
        {
            Usuario recuperar = BuscarUsuario(correo);
            if (recuperar != null)
            {
                return repUsu.EnviarCorreo(recuperar,correo);
            }
            else
            {
                return false;
            }
        }
        public string codificarContraseña(string password)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            string hash = sb.ToString();
            return hash;

        }
    }
}
