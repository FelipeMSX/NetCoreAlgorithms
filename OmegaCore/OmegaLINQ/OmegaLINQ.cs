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

        public static IOmegaNumerable<T>? Filter<T>(this IOmegaNumerable<T> collection, Func<T, bool> predicate)
        {
            OmegaListIterator<T> iterator = new OmegaListIterator<T>();
            yield return  iterator.Current;
            //foreach (T element in collection)
            //{
            //    if (predicate(element)) yield return element ;
            //}
        }

        public static IOmegaNumerable<TSource> Skip<TSource>(this IOmegaNumerable<TSource> source, int count)
        {
            return SkipIterator<TSource>(source, count);
        }

        private static IOmegaNumerable<TSource> SkipIterator<TSource>(IOmegaNumerable<TSource> source, int count)
        {
            var enumerator = source.GetEnumerator();

            using (IOmegaNumerable<TSource> e = source.GetEnumerator())
            {
                while (count > 0 && enumerator.MoveNext()) count--;
            if (count <= 0)
            {
                while (enumerator.MoveNext()) yield return enumerator.Current;
            }
            }
        }
    }

}