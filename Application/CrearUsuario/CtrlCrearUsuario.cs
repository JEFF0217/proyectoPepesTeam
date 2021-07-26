using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Domain.Usuario;
using Persistence.Factory;

namespace Application.CrearUsuario
{
    public class CtrlCrearUsuario
    {
        IRepositorioUsuario repUsu;


        public CtrlCrearUsuario()
        {
            repUsu = FabricaRepositorioUsuarios.CrearRepositorioUsuarios();
        }
        
        public bool CrearUsuario(Usuario musuario)
        {
            try
            {
                Usuario verificar = repUsu.BuscarUsuario(musuario.Correo,musuario.Identificacion);
                throw new CorreoEncontradoException("El correo electronico o identificacion ya se encuentra registrado.");
            }
            catch (UsuarioNoEncontradoException e)
            {
                string contraseña = codificarContraseña(musuario.Password);
                musuario.Password = contraseña;
                return repUsu.CrearUsuario(musuario);
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
