using OmegaCore.Collections.Interfaces;
using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.OmegaLINQ
{
    public class OmegaLINQ : IOmegaLINQ
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
}