using OmegaCore.Collections;
using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.OmegaLINQ
{
    public static class OmegaLINQ
    {
        public static T First<T>(this IOmegaEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T element in collection)
                if (predicate(element)) return element;

            throw new ElementNotFoundException();
        }

        public static T? FirstOrDefault<T>(this IOmegaEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T element in collection)
                if (predicate(element)) return element;

            return default;
        }

        public static int Count<T>(this IOmegaEnumerable<T> collection, Func<T, bool> predicate)
        {
            int count = 0;

            foreach (T element in collection)
                if (predicate(element)) count++;

            return count;
        }

        public static int Count<T>(this IOmegaEnumerable<T> collection)
        {
            int count = 0;

            foreach (T element in collection)
                count++;

            return count;
        }

        public static IOmegaEnumerable<TSource> Filter<TSource>(this IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return new OmegaFilterIterator<TSource>(source, predicate);
        }

        public static IOmegaEnumerable<TSource> Take<TSource>(this IOmegaEnumerable<TSource> source, int count)
        {
            return new OmegaTakeIterator<TSource>(source, count);
        }
    }

}