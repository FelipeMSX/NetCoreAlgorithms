using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
    public class NullObjectException : Exception, ISerializable
    {
        public const string DefaultMessage = "The object can't be null!";

        public NullObjectException() : base(DefaultMessage)
        {
        }

        public NullObjectException(string message) : base(message ?? DefaultMessage)
        {
        }

        public NullObjectException(string message, Exception innerException) : base(message ?? DefaultMessage, innerException)
        {

        }
    }
}
