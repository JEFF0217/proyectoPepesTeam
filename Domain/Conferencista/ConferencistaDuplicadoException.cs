using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Conferencista
{
    public class ConferencistaDuplicadoException : Exception
    {
        public ConferencistaDuplicadoException()
        {
        }

        public ConferencistaDuplicadoException(string message) : base(message)
        {
        }

        public ConferencistaDuplicadoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConferencistaDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
