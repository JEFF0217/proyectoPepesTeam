using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Conferencia
{
    public class ConferenciaNoEncontradaException : Exception
    {
        public ConferenciaNoEncontradaException()
        {
        }

        public ConferenciaNoEncontradaException(string message) : base(message)
        {
        }

        public ConferenciaNoEncontradaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConferenciaNoEncontradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
