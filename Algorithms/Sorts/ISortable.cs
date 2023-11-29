using OmegaCore.Collections.Interfaces;

namespace Algorithms.Sorts
{
    internal interface ISortable<T>
    {
        void Sort(IOmegaList<T> collection);
    }
}
