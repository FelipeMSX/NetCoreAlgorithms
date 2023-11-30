namespace OmegaCore.Collections.Interfaces
{
    public interface IOmegaCollection<T> : IOmegaSimpleCollection<T>
    {
        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <exception cref="Exceptions.ArgumentNullException"/>
        void Add(T? item);

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <exception cref="Exceptions.ArgumentNullException"/>
        /// <returns> Returns <see langword="true"/> when it removes with success, otherwise,
        /// <see langword="false"/>  </returns>
        bool Remove(T? item);

        /// <summary>
        /// Gets the first element in the collection.
        /// </summary>
        /// <exception cref="Exceptions.EmptyCollectionException"/>
        T First();

        /// <summary>
        /// Gets the last element in the list.
        /// </summary>
        /// <exception cref="Exceptions.EmptyCollectionException"/>
        T Last();
    }
}