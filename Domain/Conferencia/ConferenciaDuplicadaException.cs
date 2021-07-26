using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Conferencia
{
    public class ConferenciaDuplicadaException : Exception
    {
        public ConferenciaDuplicadaException()
        {
        }

        public ConferenciaDuplicadaException(string message) : base(message)
        {
        }

        public ConferenciaDuplicadaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConferenciaDuplicadaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
