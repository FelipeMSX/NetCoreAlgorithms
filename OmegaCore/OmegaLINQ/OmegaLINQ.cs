using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.OmegaLINQ
{
    public interface IOmegaLINQ
    {
        TSource First<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate);

        TSource? FirstOrDefault<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate);

        int Count<TSource>(IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate);

        int Count<TSource>(IOmegaEnumerable<TSource> collection);

        TSource[] ToArray<TSource>(IOmegaEnumerable<TSource> source);

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

            if (source is IOmegaList<TSource> list)
                return list.Count;

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

        public IOmegaEnumerable<TSource> Filter<TSource>(IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return new OmegaPredicateIterator<TSource>(source, predicate);
        }

        public IOmegaEnumerable<TSource> Take<TSource>(IOmegaEnumerable<TSource> source, int count)
        {
            return new OmegaTakeIterator<TSource>(source, count);
        }
    }

    public static class OmegaLINQ
    {
        public static IOmegaLINQ Instance { get; set; } = new InternalOmegaLINQ();

        public static TSource First<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => Instance.First(collection, predicate);

        public static TSource? FirstOrDefault<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => Instance.FirstOrDefault(collection, predicate);

        public static int Count<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => Instance.Count(collection, predicate);

        public static int Count<TSource>(this IOmegaEnumerable<TSource> collection) => Instance.Count(collection);

        public static TSource[] ToArray<TSource>(this IOmegaEnumerable<TSource> source) => Instance.ToArray(source);

        public static IOmegaEnumerable<TSource> Filter<TSource>(this IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate) => Instance.Filter(source, predicate);

        public static IOmegaEnumerable<TSource> Take<TSource>(this IOmegaEnumerable<TSource> source, int count) => Instance.Take(source, count);
    }
}