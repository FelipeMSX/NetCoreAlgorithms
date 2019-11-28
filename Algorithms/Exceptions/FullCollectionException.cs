using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
	public class FullCollectionException : Exception, ISerializable
    {
		public new const string Message = "The collection does not accept any more element";

        public FullCollectionException() : base(Message)
        {
        }

        public FullCollectionException(string message) : base(message ?? Message)
		{
		}

        public FullCollectionException(string message, Exception innerException) : base(message ?? Message, innerException)
        {
        }
    }
}
