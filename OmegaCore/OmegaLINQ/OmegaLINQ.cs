using OmegaCore.Collections;
using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.OmegaLINQ
{
    public static class OmegaLINQ
    {
        public static TSource First<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            foreach (TSource element in collection)
                if (predicate(element)) return element;

            throw new ElementNotFoundException();
        }

        public static TSource? FirstOrDefault<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            foreach (TSource element in collection)
                if (predicate(element)) return element;

            return default;
        }

        public static int Count<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate)
        {
            int count = 0;

            foreach (TSource element in collection)
                if (predicate(element)) count++;

            return count;
        }

        public static int Count<TSource>(this IOmegaEnumerable<TSource> source)
        {
            int count = 0;

            if (source is IOmegaList<TSource> list)
                return list.Count;

            if (source is IOmegaCollection<TSource> collection)
                return collection.Count;

            foreach (TSource element in source)
                count++;

            return count;
        }

        public static TSource[] ToArray<TSource>(this IOmegaEnumerable<TSource> source)
        {
            //Maybe this can generate extra allocation every time that is called
            TSource[] newArray = null;

            if (source is IOmegaCollection<TSource> collection)
            {
                newArray = new TSource[collection.Count];
                collection.CopyTo(newArray, collection.Count);
                return newArray;
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

        public static IOmegaEnumerable<TSource> Filter<TSource>(this IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return new OmegaPredicateIterator<TSource>(source, predicate);
        }

        public static IOmegaEnumerable<TSource> Take<TSource>(this IOmegaEnumerable<TSource> source, int count)
        {
            return new OmegaTakeIterator<TSource>(source, count);
        }
    }

}