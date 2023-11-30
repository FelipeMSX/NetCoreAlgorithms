using System.Runtime.Serialization;

namespace OmegaCore.Exceptions
{
    public class ArgumentException : Exception, ISerializable
    {
        public new const string Message = "Argument is not valid!";

        public ArgumentException() : base(Message) { }

        public ArgumentException(string message) : base(message ?? Message) { }

        public ArgumentException(string message, Exception innerException) : base(message ?? Message, innerException) { }
    }
}