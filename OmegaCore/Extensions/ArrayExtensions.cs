
namespace OmegaCore.Extensions
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public static class ArrayExtensions
    {
        private static IArrayUtil Instance { get; set; } = new ArrayUtil();

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.IncreaseCapacity{T}(T[], int)"/>
        /// </summary>
        public static T[] IncreaseCapacity<T>(this T[] source, int newSize) => Instance.IncreaseCapacity(source, newSize);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.OmegaCopy{T}(T[], T[], int, int)"/>
        /// </summary>
        /// <exception cref="System.ArgumentException"/>
        public static void OmegaCopy<T>(this T[] source, T[] destination, int startIndex, int endIndex) => Instance.OmegaCopy(source, destination, startIndex, endIndex);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Shift{T}(T[], int, int)"/>
        /// </summary>
        /// <exception cref="System.ArgumentException"/>
        public static void Shift<T>(this T[] source, int initIndex, int endIndex) => Instance.Shift(source, initIndex, endIndex);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Shift{T}(T[], int, int)"/>
        /// </summary>
        /// <exception cref="System.ArgumentException"/>
        public static void Shift<T>(this T[] source, int initIndex) => Instance.Shift(source, initIndex, source.Length - 1);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.IndexOf{T}(T[], T)"/>
        /// </summary>
        /// <exception cref="System.ArgumentNullException"/>
        public static int IndexOf<T>(this T[] source, T item) => Instance.IndexOf(source, item);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Clear{T}(T[], int)"/>
        /// </summary>
        public static void Clear<T>(this T[] source, int count = 0) => Instance.Clear(source, count);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Reverse{T}(T[], int)"/>
        /// </summary>
        public static void Reverse<T>(this T[] source, int count = 0) => Instance.Reverse(source, count);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Swap{T}(T[], int, int)"/>
        /// </summary>
        public static void Swap<T>(this T[] source, int sourceIndex, int destinationInex) => Instance.Swap(source, sourceIndex, destinationInex);
    }
}