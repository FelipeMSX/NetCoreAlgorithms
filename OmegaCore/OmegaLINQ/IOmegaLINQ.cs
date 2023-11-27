using OmegaCore.Interfaces;

namespace OmegaCore.OmegaLINQ
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public interface IOmegaLINQ
    {
        /// <summary>
        /// Iterates over the collection using the predicate function until find the first item that matches the predicate.
        /// <para>Throws exception if no item is found.</para>
        /// </summary>
        TSource First<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate);

        /// <summary>
        /// Iterates over the collection using the predicate function until find the first item that matches the predicate.
        /// <para>Returns null if no item matches the predicate.</para>
        /// </summary>
        /// <returns>Returns TSource or default.</returns>
        TSource? FirstOrDefault<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate);

        /// <summary>
        /// Counts all items that matches the predicate function.
        /// </summary>
        int Count<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate);

        /// <summary>
        /// Counts all items in the collection.
        /// <para>If the collection already exposes a "COUNT" the function will be optimized, 
        /// otherwise it will iterate over collection using its own iterator and counting.</para>
        /// </summary>
        int Count<TSource>(IOmegaEnumerable<TSource> collection);

        /// <summary>
        /// Converts the collection to an array.It will optimize when the collection exposes a CopyTo function.
        /// </summary>
        /// <returns>Returns a array of items or an empty array</returns>
        TSource[] ToArray<TSource>(IOmegaEnumerable<TSource> source);

        /// <summary>
        /// Returns true if some item in the collection matches the predicate function, otherwise it will return false.
        /// </summary>
        bool Some<TSource>(IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Executes an action over each item on the collection.
        /// </summary>
        void ForEach<TSource>(IOmegaEnumerable<TSource> source, Action<TSource> action);

        /// <summary>
        /// Uses a filter function to create a filter iterator to be subsequently used, 
        /// the iterator will filter all items that matches with the predicate function.
        /// </summary>
        IOmegaEnumerable<TSource> Filter<TSource>(IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate);

        /// <summary>
        /// Uses a take function to create a take iterator to be subsequently used, 
        /// the iterator will be stopped when the internal count reaches the same value passed in the count parameter.
        /// </summary>
        IOmegaEnumerable<TSource> Take<TSource>(IOmegaEnumerable<TSource> source, int count);
    }
}