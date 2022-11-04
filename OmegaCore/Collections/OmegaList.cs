using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.Collections
{
    public class OmegaList<T> : IOmegaList<T>
    {
        private readonly T[] _internalArray;
        public T this[int index] { get => _internalArray[index]; set => _internalArray[index] = value; }

        public int Count {get; private set; }   


        //TODO - Does it to create a new copy?
        public OmegaList(T[] internalArray)
        {
            _internalArray = internalArray;
        }

        public OmegaList()
        {
            _internalArray = Array.Empty<T>();
        }

        public void Add(T item)
        {
            if(item == null)
                throw new ArgumentNullException("item");

            _internalArray[Count++] = item;
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public T First()
        {
            return _internalArray[0];
        }



        public T Last()
        {
            return _internalArray[Count -1];

        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public T Retrieve(T item)
        {
            throw new System.NotImplementedException();
        }

        IOmegaNumerator<T> IOmegaNumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IOmegaNumerator IOmegaNumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
