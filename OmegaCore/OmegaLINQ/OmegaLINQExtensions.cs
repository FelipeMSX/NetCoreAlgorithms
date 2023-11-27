using OmegaCore.Exceptions;
using OmegaCore.Interfaces;

namespace OmegaCore.OmegaLINQ
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public static class OmegaLINQExtensions
    {
        private static readonly IOmegaLINQ _instance = new OmegaLINQ();

        /// <summary>
        /// <inheritdoc cref="IOmegaLINQ.First"/>
        /// </summary>
        /// <exception cref="ElementNotFoundException"></exception>
        public static TSource First<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => _instance.First(collection, predicate);

        /// <summary>
        /// <inheritdoc cref="IOmegaLINQ.FirstOrDefault"/>
        /// </summary>
        public static TSource? FirstOrDefault<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => _instance.FirstOrDefault(collection, predicate);

        /// <summary>
        /// <inheritdoc cref="IOmegaLINQ.Count{TSource}(IOmegaEnumerable{TSource}, Func{TSource, bool})"/>
        /// </summary>
        public static int Count<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => _instance.Count(collection, predicate);

        /// <summary>
        /// <inheritdoc cref="IOmegaLINQ.Count{TSource}(IOmegaEnumerable{TSource})"/>
        /// </summary>
        public static int Count<TSource>(this IOmegaEnumerable<TSource> collection) => _instance.Count(collection);

        /// <summary>
        /// <inheritdoc cref="IOmegaLINQ.Some"/>
        /// </summary>
        public static bool Some<TSource>(this IOmegaEnumerable<TSource> collection, Func<TSource, bool> predicate) => _instance.Some(collection, predicate);


        /// <summary>
        /// <inheritdoc cref="IOmegaLINQ.ForEach"/>
        /// </summary>
        public static void ForEach<TSource>(this IOmegaEnumerable<TSource> source, Action<TSource> action) => _instance.ForEach(source, action);

        /// <summary>
        /// <inheritdoc cref="IOmegaLINQ.ToArray"/>
        /// </summary>
        public static TSource[] ToArray<TSource>(this IOmegaEnumerable<TSource> source) => _instance.ToArray(source);

        /// <summary>
        /// <inheritdoc cref="IOmegaLINQ.Filter"/>
        /// </summary>
        public static IOmegaEnumerable<TSource> Filter<TSource>(this IOmegaEnumerable<TSource> source, Func<TSource, bool> predicate) => _instance.Filter(source, predicate);

        /// <summary>
        /// <inheritdoc cref="IOmegaLINQ.Take"/>
        /// </summary>
        public static IOmegaEnumerable<TSource> Take<TSource>(this IOmegaEnumerable<TSource> source, int count) => _instance.Take(source, count);
    }
}