using OmegaCore.Interfaces;

namespace OmegaCore.Collections.Interfaces
{
    public interface IOmegaSimpleCollection<T> : IOmegaEnumerable<T>, IOmegaDisposable
    {
        /// <summary>
        /// Represents the current count of the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns <see langword="true"/> when the collection is empty.
        /// </summary>
        bool IsEmpty();

        /// <summary>
        /// Removes all elements in the collection.
        /// </summary>
        void Clear();

        /// <summary>
        /// Copies all the elments from the collection to the destination array.
        /// </summary>
        /// <param name="startIndex">Defines the start position in the destination array to begin the copy</param>
        void CopyTo(T[] array, int startIndex);
    }
}