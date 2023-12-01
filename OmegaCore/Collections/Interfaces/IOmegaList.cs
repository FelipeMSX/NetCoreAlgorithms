namespace OmegaCore.Collections.Interfaces
{
    public interface IOmegaList<T> : IOmegaCollection<T>, IResizableCollection
    {
        /// <summary>
        /// Quick access to the list.
        /// </summary>
        T this[int index] { get; }

        /// <summary>
        /// Changes the position between two items. 
        /// </summary>
        void Swap(int source, int destination);
    }
}