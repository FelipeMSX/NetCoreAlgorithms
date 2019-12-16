using System;
using System.Collections.Generic;
using Algorithms.Abstracts;
using Algorithms.Exceptions;

namespace Algorithms.Collections
{

    public class StaticStack<T> : QueueStackBase<T> 
	{
  
		public StaticStack(Comparison<T> comparator) : base(comparator)
		{
		}

        public StaticStack(int maxsize, Comparison<T> comparator, bool resizable = true, bool allowEqualsElements = true) 
            : base (maxsize, comparator, resizable, allowEqualsElements)
		{
		}


		public override void Push(T obj)
		{
            //Validações
			if (obj == null)
				throw new NullObjectException();
			if (Full())
				IncreaseCapacity(DefaultSize);

			Vector[Count++] = obj;
		}

		public override T Pop()
		{
			if (Empty())
				throw new EmptyCollectionException();

			T temp = Vector[--Count];
			Vector[Count] = default(T);

			return temp;
		}

        public override T Peek()
        {
            if (Empty())
                throw new EmptyCollectionException();

            return Vector[Count - 1];
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }
    }
}
