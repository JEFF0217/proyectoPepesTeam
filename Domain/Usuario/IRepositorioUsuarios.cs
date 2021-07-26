using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Usuario
{
    public interface IRepositorioUsuario
    {

        Usuario GetUsuario(int Id);

        bool CrearUsuario(Usuario usu);

        Usuario BuscarUsuario(string correo,string identificacion);

        bool EnviarCorreo(Usuario recuperar,string correo);


    }
}
