using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Domain.Aula
{
   public  class AulaNoEncontradaException : Exception
    {
        public AulaNoEncontradaException()
        {
        }

        public AulaNoEncontradaException(string message) : base(message)
        {
        }

        public AulaNoEncontradaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AulaNoEncontradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
