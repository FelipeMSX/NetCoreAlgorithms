using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
    public class NullParameterException : Exception, ISerializable
    {
        public new const string Message = "The object can't be null!";

        public NullParameterException() : base(Message){}

        public NullParameterException(string message) : base(message ?? Message){}

        public NullParameterException(string message, Exception innerException) : base(message ?? Message, innerException){}
    }
}
