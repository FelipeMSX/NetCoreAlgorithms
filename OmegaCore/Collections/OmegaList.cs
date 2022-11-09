using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.Collections
{
    public class OmegaList<T> : IOmegaList<T>
    {
        private const int INITIAL_CAPACITY = 100;
        private T[] _internalArray;

        public T this[int index] { get => _internalArray[index]; set => _internalArray[index] = value; }

        public int Count { get; private set; }


        //TODO - Does it need to create a new copy?
        public OmegaList(T[] elements)
        {
            _internalArray = new T[elements.Length];
            elements.CopyTo(_internalArray, 0);
            Count = elements.Length;
        }

        public OmegaList(int capacity = INITIAL_CAPACITY)
        {
            _internalArray = new T[capacity];
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _internalArray[Count++] = item;
        }

        public void Clear()
        {
            _internalArray = new T[INITIAL_CAPACITY];
            Count = 0;
        }

        public T First() => _internalArray[0];

        public T Last() => _internalArray[Count - 1];

        public bool IsEmpty() => Count == 0;

        public bool Remove(T item)
        {
            if (IsEmpty())
                return false;

            int index = 0;

            while (index < Count)
            {
                if (item.Equals(_internalArray[index]))
                {
                    //Shift the itens.
                    for (int i = index; i < Count; i++)
                        _internalArray[i] = _internalArray[i + 1];

                    _internalArray[Count - 1] = default;
                    Count--;
                    return true;

                }
                index++;
            }

            return false;
        }

        public T Retrieve(T item)
        {
            if (IsEmpty())
                throw new EmptyCollectionException(); ;

            int index = 0;

            while (index < Count)
            {
                if (item.Equals(_internalArray[index]))
                {
                    return _internalArray[index];
                }
                index++;
            }

            throw new ElementNotFoundException();
        }

        public IOmegaEnumerator<T> GetEnumerator()
        {
            return new OmegaListIterator<T>(this);
        }

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()
        {
            _internalArray = null;
        }

        public void CopyTo(T[] array, int lenght)
        {
            for (int i = 0; i < lenght; i++)
                array[i] = this[i];
        }
    }
}
