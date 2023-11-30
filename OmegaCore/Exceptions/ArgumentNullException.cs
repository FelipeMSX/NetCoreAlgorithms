using System.Runtime.Serialization;

namespace OmegaCore.Exceptions
{
    public class ArgumentNullException : Exception, ISerializable
    {
        public new const string Message = "The object can't be null!";

        public ArgumentNullException() : base(Message){}

        public ArgumentNullException(string message) : base(message ?? Message){}

        public ArgumentNullException(string message, Exception innerException) : base(message ?? Message, innerException){}

        public static void CheckAgainstNull<TValue>(TValue value, string paramName)
        {
            if (value == null) throw new ArgumentNullException($"The object with name: {paramName} is null");
        }
    }
}