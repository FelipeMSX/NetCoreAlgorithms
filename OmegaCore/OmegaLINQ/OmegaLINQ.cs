using OmegaCore.Collections;
using OmegaCore.Exceptions;
using OmegaCore.Interfaces;
using OmegaCore.Iterators;

namespace OmegaCore.OmegaLINQ
{
    public static class OmegaLINQ
    {
        public static T First<T>(this IOmegaNumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T element in collection)
                if (predicate(element)) return element;

            throw new ElementNotFoundException();
        }

        public static T? FirstOrDefault<T>(this IOmegaNumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T element in collection)
                if (predicate(element)) return element;

            return default;
        }

        //public static IOmegaNumerable<T> Filter<T>(this IOmegaNumerable<T> collection, Func<T, bool> predicate)
        //{
        //    IOmegaList<T> list = new OmegaList<T>();

        //    foreach (T element in collection)
        //        if (predicate(element))
        //            list.Add(element); 

        //    return list;
        //}


        public static IOmegaNumerable<TSource> Filter<TSource>(this IOmegaNumerable<TSource> source, Func<TSource, bool> predicate)
        {
            //IOmegaList<T> list = new OmegaList<T>();

            return (IOmegaNumerable<TSource>)FilterIterator(source, predicate);
        }

        private static IEnumerable<TSource> FilterIterator<TSource>(IOmegaNumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource element in source)
                if (predicate(element)) yield return element;
        }

        public static IEnumerable<TSource> Take<TSource>(this IOmegaNumerable<TSource> source, int count)
        {
            return TakeIterator(source, count);
        }

        private static IEnumerable<TSource> TakeIterator<TSource>(IOmegaNumerable<TSource> source, int count)
        {
            if (count <= 0)
                yield break;

            foreach (TSource element in source)
            {
                yield return element;
                if (--count == 0) break;
            }
        }
    }

}