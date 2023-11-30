using OmegaCore.Interfaces;

namespace OmegaCore.Iterators
{
    /// <summary>
    /// Defines the base class to be used in every iterator in the lib. 
    /// <para><author>Felipe Morais: felipeprodev@gmail.com</author></para>
    /// </summary>
    public abstract class OmegaIteratorBase<T> : IOmegaEnumerator<T>, IOmegaEnumerable<T>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public T Current { get; protected set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        object IOmegaEnumerator.Current => Current!;

        public abstract bool MoveNext();
        public abstract void Reset();
        public abstract void Dispose();

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator() => GetEnumerator();

        public IOmegaEnumerator<T> GetEnumerator() => this;

    }
}