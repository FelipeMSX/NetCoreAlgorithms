using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
	public class ValueNotValidException : Exception, ISerializable
	{
		public new const string Message = "The value is not valid!";

        public ValueNotValidException() : base(Message)
        {
        }

        public ValueNotValidException(string message) : base(message ?? Message)
		{
		}

        public ValueNotValidException(string message, Exception innerException) : base(message ?? Message, innerException)
        {
        }
    }
}
