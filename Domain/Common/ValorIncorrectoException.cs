using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Common
{
    public class ValorIncorrectoException : Exception
    {
        public ValorIncorrectoException()
        {
        }

        public ValorIncorrectoException(string message) : base(message)
        {
        }

        public ValorIncorrectoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValorIncorrectoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
