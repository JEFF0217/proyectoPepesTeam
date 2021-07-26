using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Usuario
{
    public class UsuarioNoEncontradoException : Exception
    {
        public UsuarioNoEncontradoException()
        {
        }

        public UsuarioNoEncontradoException(string message) : base(message)
        {
        }

        public UsuarioNoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsuarioNoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
