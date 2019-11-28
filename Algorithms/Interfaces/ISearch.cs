using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Interfaces
{
    public interface ISearch<T> : IDefaultComparator<T>
    {
        T BinarySearch(IList<T> orderedArray, T item);
    }
}
