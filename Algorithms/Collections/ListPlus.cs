using System.Text;
using System.Threading.Tasks;
using OmegaCore.Interfaces;

namespace Algorithms.Collections
{
    public class ListPlus<T> : OmegaCore.Interfaces.IOmegaList<T>
    {
        public T this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Count => throw new System.NotImplementedException();

        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public T First()
        {
            throw new System.NotImplementedException();
        }



        public T Last()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public T Retrieve(T item)
        {
            throw new System.NotImplementedException();
        }

        public IOmegaEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IOmegaEnumerator IOmegaEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        void IOmegaCollection<T>.CopyTo(T[] array, int lenght)
        {
            throw new System.NotImplementedException();
        }
    }
}
