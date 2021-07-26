using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Evento
{
    public class AsistenciaEventoException : Exception
    {
        public AsistenciaEventoException()
        {
        }

        public AsistenciaEventoException(string message) : base(message)
        {
        }

        public AsistenciaEventoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AsistenciaEventoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
