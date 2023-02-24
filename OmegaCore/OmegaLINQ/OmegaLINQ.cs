using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.OmegaLINQ
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public interface IOmegaLINQ
    {
        TSource First<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate);

        TSource? FirstOrDefault<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate);

        int Count<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate);

        int Count<TSource>(IOmegaEnumerable<TSource> collection);

        TSource[] ToArray<TSource>(IOmegaEnumerable<TSource> source);

        bool Some<TSource>(IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate);

        void ForEach<TSource>(IOmegaEnumerable<TSource> source, Action<TSource> action);

        IOmegaEnumerable<TSource> Filter<TSource>(IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate);

        IOmegaEnumerable<TSource> Take<TSource>(IOmegaEnumerable<TSource> source, int count);

    }

    public class InternalOmegaLINQ : IOmegaLINQ
    {
        public TSource First<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            foreach (TSource element in collection)
                if (predicate(element)) return element;

            throw new ElementNotFoundException();
        }

        public TSource? FirstOrDefault<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            foreach (TSource element in collection)
                if (predicate(element)) return element;

            return default;
        }

        public int Count<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            int count = 0;

            foreach (TSource element in collection)
                if (predicate(element)) count++;

            return count;
        }

        public int Count<TSource>(IOmegaEnumerable<TSource> source)
        {
            int count = 0;

            if (source is IOmegaSimpleCollection<TSource> collection)
                return collection.Count;

            foreach (TSource element in source)
                count++;

            return count;
        }

        public TSource[] ToArray<TSource>(IOmegaEnumerable<TSource> source)
        {
            TSource[]? newArray;

            if (source is IOmegaSimpleCollection<TSource> collection)
            {
                newArray = new TSource[collection.Count];
                collection.CopyTo(newArray, 0);
            }
            else
            {
                newArray = new TSource[Count(source)];
                int index = 0;

                foreach (TSource element in source)
                    newArray[index++] = element;
            }

            return newArray;
        }

        public bool Some<TSource>(IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource element in source)
                if (predicate(element)) return true;

            return false;
        }

        public void ForEach<TSource>(IOmegaEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (TSource element in source)
                action(element);
        }

        public IOmegaEnumerable<TSource> Filter<TSource>(IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return new OmegaPredicateIterator<TSource>(source, predicate);
        }

        public IOmegaEnumerable<TSource> Take<TSource>(IOmegaEnumerable<TSource> source, int count)
        {
            return new OmegaTakeIterator<TSource>(source, count);
        }
    }

    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public static class OmegaLINQ
    {
        /// <summary>
        /// TO-DO: Finds out a way to make the Instance not public or accessible. This is a work around to enable mocking in tests.
        /// </summary>
        public static IOmegaLINQ Instance { get; set; } = new InternalOmegaLINQ();

        /// <summary>
        /// Iterates over the collection using the predicate function until find the first item that matches the predicate.
        /// <para>Throws exception if no item is found.</para>
        /// </summary>
        /// <exception cref="ElementNotFoundException"></exception>
        public static TSource First<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => Instance.First(collection, predicate);

        /// <summary>
        /// Iterates over the collection using the predicate function until find the first item that matches the predicate.
        /// <para>Returns null if no item matches the predicate.</para>
        /// </summary>
        /// <returns>Returns TSource or default.</returns>
        public static TSource? FirstOrDefault<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => Instance.FirstOrDefault(collection, predicate);

        /// <summary>
        /// Counts all items that matches the predicate function.
        /// <para>If the collection already exposes a "COUNT" the function will be optimized, otherwise it will iterate over collection using its own iterator and counting</para>
        /// </summary>
        public static int Count<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => Instance.Count(collection, predicate);

        /// <summary>
        /// Counts all items in the collection.
        /// <para>If the collection already exposes a "COUNT" the function will be optimized, otherwise it will iterate over collection using its own iterator and counting</para>
        /// </summary>
        public static int Count<TSource>(this IOmegaEnumerable<TSource> collection) => Instance.Count(collection);

        /// <summary>
        /// Returns true if some item in the collection matches the predicate function, otherwise it will return false.
        /// </summary>
        public static bool Some<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => Instance.Some(collection, predicate);

        /// <summary>
        /// Executes an action over each item on the collection.
        /// </summary>
        public static void ForEach<TSource>(this IOmegaEnumerable<TSource> source, Action<TSource> action) => Instance.ForEach(source, action);

        /// <summary>
        /// Converts the collection to an array.It will optimize when the collection exposes a CopyTo function.
        /// </summary>
        /// <returns>Returns a array of items or an empty array</returns>
        public static TSource[] ToArray<TSource>(this IOmegaEnumerable<TSource> source) => Instance.ToArray(source);

        /// <summary>
        /// Uses a filter function to create a filter iterator to be subsequently used, the iterator will filter all items that matches with the predicate function.
        /// </summary>
        public static IOmegaEnumerable<TSource> Filter<TSource>(this IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate) => Instance.Filter(source, predicate);

        /// <summary>
        /// Uses a take function to create a take iterator to be subsequently used, the iterator will be stopped when the internal count reaches the same value passed in the count parameter.
        /// </summary>
        public static IOmegaEnumerable<TSource> Take<TSource>(this IOmegaEnumerable<TSource> source, int count) => Instance.Take(source, count);
    }
}