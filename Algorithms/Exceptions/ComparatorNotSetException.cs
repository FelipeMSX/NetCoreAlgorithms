using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
	public class ComparatorNotSetException : Exception, ISerializable
    {
		public const string DefaultMessage = "Comparer can't be null";

        public ComparatorNotSetException() : base(DefaultMessage)
        {
        }

        public ComparatorNotSetException(string message) : base(message ?? DefaultMessage)
		{
		}

        public ComparatorNotSetException(string message, Exception innerException) : base(message ?? DefaultMessage, innerException)
        {
        }
    }
}
