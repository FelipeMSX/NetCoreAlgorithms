using System;
using System.Collections.Generic;
using Algorithms.Abstracts;
using Algorithms.Exceptions;

namespace Algorithms.Collections.Static
{

    /// <summary>
    /// This collection represents a static queue.
    /// </summary>
	public class Queue<T> : QueueStackBase<T>
    {
		public Queue(Comparison<T> comparator) : base(comparator)
		{
		}

        public Queue(int maxsize, Comparison<T> comparator, bool resizable = true)
            : base(maxsize, comparator, resizable)
		{
		}


        /// <summary>
        /// Adds a new item in the ending of the queue.
        /// </summary>
		public override void Push(T obj)
		{
			//Validações
			if (obj == null)
				throw new NullObjectException();
            else
			if (Full() && !Resizable)
				throw new FullCollectionException();
            else
            if (Full())
            {
                IncreaseCapacity(DefaultSize);
            }
			Vector[Count++] = obj;
		}

        public override IEnumerator<T> GetEnumerator()
        {
           for(int i = 0; i < Count; i++)
                yield return this[i];
        }

        /// <summary>
        /// Removes the first item to comes out. All items must be shifted in one position.
        /// </summary>
        public override T Pop()
		{
			if (Empty())
				throw new EmptyCollectionException();

			T item = Vector[0];

            Count--;
            //Shifts the itens.
            for (int i = 0; i < Count; i++)
				Vector[i] = Vector[i + 1];

			return item;
		}


        /// <summary>
        /// Retrieves the first item from the collection, but it remains in the collection.
        /// </summary>
        public override T Peek()
        {
            if (Empty())
                throw new EmptyCollectionException();

            return Vector[0];
        }
    }
}
