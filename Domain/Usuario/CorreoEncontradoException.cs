using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Usuario
{
    public class CorreoEncontradoException : Exception
    {
        public CorreoEncontradoException()
        {
        }

        public CorreoEncontradoException(string message) : base(message)
        {
        }

        public CorreoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CorreoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
