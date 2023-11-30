using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Interfaces
{
    //IDefaultComparator<T>
    public interface ISearch<T> 
    {
        T BinarySearch(IList<T> orderedArray, T item);
    }
}
