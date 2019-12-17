using System;
using System.Collections.Generic;
using Algorithms.Abstracts;
using Algorithms.Exceptions;

namespace Algorithms.Collections
{

    /// <summary>
    /// Represents a stack and it was implemented using a vector.
    /// </summary>
    public class StaticStack<T> : QueueStackBase<T> 
	{
  
		public StaticStack(Comparison<T> comparator) : base(comparator)
		{
		}

        public StaticStack(int maxsize, Comparison<T> comparator, bool resizable = true, bool allowEqualsElements = true) 
            : base (maxsize, comparator, resizable, allowEqualsElements)
		{
		}

        /// <summary>
        /// Puts a item in the stack and putting a item in the end of the vector.
        /// </summary>
		public override void Push(T obj)
		{
            //Validações
            if (obj == null)
                throw new NullObjectException();
            if (Full() && !Resizable)
                throw new FullCollectionException();
            else
            if (Full())
            {
                IncreaseCapacity(DefaultSize);
            }

            Vector[Count++] = obj;
		}


        /// <summary>
        /// Removes the item in the top of the stack.
        /// </summary>
		public override T Pop()
		{
			if (Empty())
				throw new EmptyCollectionException();

			T temp = Vector[--Count];
			Vector[Count] = default(T);

			return temp;
		}

        /// <summary>
        /// Retrieves the item in the top of the stack without removing it.
        /// </summary>
        public override T Peek()
        {
            if (Empty())
                throw new EmptyCollectionException();

            return Vector[Count - 1];
        }

        public override T First() => Empty() ? default(T) : Vector[Count - 1];

        public override T Last() => Empty() ? default(T) : Vector[0];

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }
    }
}
