using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
	public class EmptyCollectionException : Exception, ISerializable
    {
		public new const string Message = "This collection does not contain any element!";


        public EmptyCollectionException() : base(Message)
        {
        }

        public EmptyCollectionException(string message) : base(message ?? Message)
		{
		}

        public EmptyCollectionException(string message, Exception innerException) : base(message ?? Message, innerException)
        {
        }
    }
}
