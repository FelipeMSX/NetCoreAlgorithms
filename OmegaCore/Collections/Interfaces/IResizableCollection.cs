namespace OmegaCore.Collections.Interfaces
{
    public interface IResizableCollection
    {
        /// <summary>
        /// Defines the max capacity of the queue and it works in conjunction with <see cref="Resizable"/> property.
        /// </summary>
        public int MaxCapacity { get; }

        /// <summary>
        /// Controls whether the queue can auto resize when it reaches the max value.
        /// </summary>
        public bool Resizable { get; }

        /// <summary>
        /// Returns <see langword="true"/> when the collection reaches the full capacity.
        /// </summary>
        bool IsFull();
    }
}
