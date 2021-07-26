using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Evento
{
    public class EventoNoEncontradoException : Exception
    {
        public EventoNoEncontradoException()
        {
        }

        public EventoNoEncontradoException(string message) : base(message)
        {
        }

        public EventoNoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EventoNoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
