using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
	public class EqualsElementException : Exception, ISerializable
    {
		public new const string Message = "Equals elements are not allowed!";

        public EqualsElementException() : base(Message)
        {
        }

        public EqualsElementException(string message) : base(Message)
		{
		}

        public EqualsElementException(string message, Exception innerException) : base(message ?? Message, innerException)
        {
        }
    }
}
