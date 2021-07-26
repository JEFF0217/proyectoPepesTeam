using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.ApiKey
{
    public class ApiKeyNoEncontradaException : Exception
    {
        public ApiKeyNoEncontradaException()
        {
        }

        public ApiKeyNoEncontradaException(string message) : base(message)
        {
        }

        public ApiKeyNoEncontradaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiKeyNoEncontradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
