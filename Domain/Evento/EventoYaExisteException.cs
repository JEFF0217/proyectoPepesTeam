using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Evento
{
    public class EventoYaExisteException : Exception
    {
        public EventoYaExisteException()
        {
        }

        public EventoYaExisteException(string message) : base(message)
        {
        }

        public EventoYaExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EventoYaExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
