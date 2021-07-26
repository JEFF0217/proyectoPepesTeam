using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Inscripcion
{
    public class InscripcionDuplicadaException : Exception
    {
        public InscripcionDuplicadaException()
        {
        }

        public InscripcionDuplicadaException(string message) : base(message)
        {
        }

        public InscripcionDuplicadaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InscripcionDuplicadaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
