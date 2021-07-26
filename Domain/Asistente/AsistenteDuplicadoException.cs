using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Asistente
{
    public class AsistenteDuplicadoException : Exception
    {
        public AsistenteDuplicadoException()
        {
        }

        public AsistenteDuplicadoException(string message) : base(message)
        {
        }

        public AsistenteDuplicadoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AsistenteDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
