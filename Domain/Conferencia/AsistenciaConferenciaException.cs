using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Conferencia
{
    public class AsistenciaConferenciaException : Exception
    {
        public AsistenciaConferenciaException()
        {
        }

        public AsistenciaConferenciaException(string message) : base(message)
        {
        }

        public AsistenciaConferenciaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AsistenciaConferenciaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
