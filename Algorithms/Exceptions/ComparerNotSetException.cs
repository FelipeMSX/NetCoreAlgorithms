using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
	public class ComparerNotSetException : Exception, ISerializable
    {
		public const string DefaultMessage = "Comparer can't be null";

        public ComparerNotSetException() : base(DefaultMessage)
        {
        }

        public ComparerNotSetException(string message) : base(message ?? DefaultMessage)
		{
		}

        public ComparerNotSetException(string message, Exception innerException) : base(message ?? DefaultMessage, innerException)
        {
        }
    }
}
