using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Conferencista
{
    public class ConferencistaNoEncontradoException : Exception
    {
        public ConferencistaNoEncontradoException()
        {
        }

        public ConferencistaNoEncontradoException(string message) : base(message)
        {
        }

        public ConferencistaNoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConferencistaNoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
