using System.Runtime.Serialization;

namespace OmegaCore.Exceptions
{
    public class ElementNotFoundException : Exception, ISerializable
    {
        public new const string Message = "The object can't be found in this collection!";

        public ElementNotFoundException() : base(Message){}

        public ElementNotFoundException(string message) : base(message ?? Message) {}

        public ElementNotFoundException(string message, Exception innerException) : base(message ?? Message, innerException){}
    }
}
