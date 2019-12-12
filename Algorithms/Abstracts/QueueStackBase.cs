using System;

namespace Algorithms.Abstracts
{

	public abstract class QueueStackBase<T> : ArrayBase<T>
	{

		public abstract void Push(T obj);
		public abstract T Pop();
        public abstract T Peek();

        protected QueueStackBase(Comparison<T> comparator) : base(comparator)
        {
        }

        protected QueueStackBase(int maxsize, Comparison<T> comparator, bool resizable = true, bool allowEqualsElements = true)
            : base(maxsize, comparator, resizable, allowEqualsElements)
        {
        }
    }
}
