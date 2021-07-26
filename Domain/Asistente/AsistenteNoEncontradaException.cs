using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Asistente
{
    public class AsistenteNoEncontradaException : Exception
    {
        public AsistenteNoEncontradaException()
        {
        }

        public AsistenteNoEncontradaException(string message) : base(message)
        {
        }

        public AsistenteNoEncontradaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AsistenteNoEncontradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
