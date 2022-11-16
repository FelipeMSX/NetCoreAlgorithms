using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
    public class NullParameterException : Exception, ISerializable
    {
        public const string DefaultMessage = "The object can't be null!";

        public NullParameterException() : base(DefaultMessage)
        {
        }

        public NullParameterException(string message) : base(message ?? DefaultMessage)
        {
        }

        public NullParameterException(string message, Exception innerException) : base(message ?? DefaultMessage, innerException)
        {

        }
    }
}
