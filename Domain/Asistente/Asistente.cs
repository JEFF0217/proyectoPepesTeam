using System;
using System.Collections.Generic;
using System.Text;
using Domain.Usuario;

namespace Domain.Asistente
{
    public class Asistente: Usuario.Usuario
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
