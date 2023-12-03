using OmegaCore.Collections.Interfaces;

namespace Algorithms.Sorts
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    internal interface ISortable<T>
    {
        void Sort(IOmegaList<T> collection);
    }
}
