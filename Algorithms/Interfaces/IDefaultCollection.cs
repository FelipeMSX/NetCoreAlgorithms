using System.Collections.Generic;

namespace Algorithms.Interfaces
{
    public interface IDefaultCollection<T> : IEnumerable<T>, IEnumerableHelper<T>
    {
        int Count {get;}
        void Add(T item);
        bool Remove(T item);
        T Retrieve(T item);
        T First();
        T Last();
        void Clear();
    }
}
