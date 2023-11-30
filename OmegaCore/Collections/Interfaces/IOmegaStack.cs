namespace OmegaCore.Collections.Interfaces
{
    public interface IOmegaStack<T> : IOmegaSimpleCollection<T>, IResizableCollection
    {
        /// <summary>
        /// Quick access to the stack, the first element is stored in end.
        /// Uses Count to get the first item
        /// </summary>
        T this[int index] { get; }

        /// <summary>
        /// Adds a new item in the stack.
        /// <para>Time: <b>O(1)</b></para>
        /// </summary>
        /// <exception cref="Exceptions.ArgumentNullException"></exception>
        /// <exception cref="Exceptions.FullCollectionException"></exception>
        void Push(T? item);

        /// <summary>
        /// Removes the first item to comes out in the stack. 
        /// <para>Time: <b>O(1)</b></para>
        /// </summary>
        /// <exception cref="Exceptions.EmptyCollectionException"></exception>
        T Pop();

        /// <summary>
        /// Retrieves the first item from the collection, but it remains in the collection.
        /// <para>Time: <b>O(1)</b> to get the element</para>
        /// </summary>
        /// <exception cref="Exceptions.EmptyCollectionException"></exception>
        T Peek();
    }
}