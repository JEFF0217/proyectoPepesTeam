using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Aula
{
   public class AulaDuplicadaException : Exception
    {
        public AulaDuplicadaException()
        {
        }

        public AulaDuplicadaException(string message) : base(message)
        {
        }

        public AulaDuplicadaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AulaDuplicadaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
