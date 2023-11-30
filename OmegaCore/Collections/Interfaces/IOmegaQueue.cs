namespace OmegaCore.Collections.Interfaces
{
    public interface IOmegaQueue<T> : IOmegaSimpleCollection<T>, IResizableCollection
    {
        /// <summary>
        /// A quick access to the queue, the first element is stored in the index 0.
        /// </summary>
        T this[int index] { get; }

        /// <summary>
        /// Adds a new item in the queue. If the collection is <see cref="IResizableCollection.Resizable"/> grows its size automatically.
        /// <para>Time: <b>O(1)</b> to add a new element.</para>
        /// </summary>
        /// <exception cref="OmegaCore.Exceptions.ArgumentNullException"/>
        /// <exception cref="OmegaCore.Exceptions.FullCollectionException"/>
        void Queue(T? item);

        /// <summary>
        /// Removes the first item in the beginning of the array. All remaining items must be shifted in one position.
        /// <para>Time: <b>O(N)</b>.</para>
        /// </summary>
        /// <exception cref="Exceptions.EmptyCollectionException"/>
        T Unqueue();

        /// <summary>
        /// Retrieves the first item from the collection, but it remains in the collection.
        /// <para>Time: <b>O(1)</b> to get the element.</para>
        /// </summary>
        /// <exception cref="Exceptions.EmptyCollectionException"/>
        T Peek();
    }
}