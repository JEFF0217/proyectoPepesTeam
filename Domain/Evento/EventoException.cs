using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Evento
{
    public class EventoException : Exception
    {
        public EventoException()
        {
        }

        public EventoException(string message) : base(message)
        {
        }

        public EventoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EventoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
