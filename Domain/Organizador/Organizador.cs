using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Organizador
{
    public class Organizador : Usuario.Usuario
    {
        public int IdUsuario { get; set; }

        public void setUsuario(Usuario.Usuario user)
        {
            this.Id = user.Id;
            this.Nombre = user.Nombre;
            this.Apellido = user.Apellido;
            this.Correo = user.Correo;
            this.Password = user.Password;
            this.Identificacion = this.Identificacion;
        }
    }
}
