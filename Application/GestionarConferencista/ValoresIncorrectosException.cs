using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.GestionarConferencista
{
    class ValoresIncorrectosException : Exception
    {
        public ValoresIncorrectosException()
        {
        }

        public ValoresIncorrectosException(string message) : base(message)
        {
        }

        public ValoresIncorrectosException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValoresIncorrectosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
