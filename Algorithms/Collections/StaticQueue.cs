using System;
using System.Collections.Generic;
using Algorithms.Abstracts;
using Algorithms.Exceptions;

namespace Algorithms.Collections
{

	public class StaticQueue<T> : QueueStackBase<T>
    {
		public StaticQueue(Comparison<T> comparator) : base(comparator)
		{
		}

        public StaticQueue(int maxsize, Comparison<T> comparator, bool resizable = true, bool allowEqualsElements = true)
            : base(maxsize, comparator, resizable, allowEqualsElements)
		{
		}

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

        public override T Pop()
		{
			if (Empty())
				throw new EmptyCollectionException();

			T item = Vector[0];

            Count--;
            //Desloca os itens
            for (int i = 0; i < Count; i++)
			{
				Vector[i] = Vector[i + 1];
			}

			return item;
		}

        public override T Peek()
        {
            if (Empty())
                throw new EmptyCollectionException();

            return Vector[0];
        }
    }
}
