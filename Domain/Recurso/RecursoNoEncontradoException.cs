using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Recurso
{
    public class RecursoNoEncontradoException : Exception
    {
        public RecursoNoEncontradoException()
        {
        }

        public RecursoNoEncontradoException(string message) : base(message)
        {
        }

        public RecursoNoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RecursoNoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
