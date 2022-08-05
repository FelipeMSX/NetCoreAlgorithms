﻿using Core.Interfaces;

namespace Core.Abstracts
{
    public abstract class Iterator<T> : INumerator<T?>, INumerator
    {
        public T? Current { get; protected set; }

        object INumerator.Current
        {
            get
            {
                if (Current == null)
                    throw new NullReferenceException();

                return Current;
            }
        }

        public abstract bool MoveNext();
        public abstract void Reset();
    }
}