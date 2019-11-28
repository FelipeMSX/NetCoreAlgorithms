using System;
using System.Runtime.Serialization;

namespace Algorithms.Exceptions
{
	public class ElementNotFoundException : Exception, ISerializable
    {
		public new const string Message = "The object can't be found in this collection!";


        public ElementNotFoundException() : base(Message)
        {
        }

        public ElementNotFoundException(string message) : base(Message)
		{
		}

        public ElementNotFoundException(string message, Exception innerException) : base(message ?? Message, innerException)
        {
        }
    }
}
