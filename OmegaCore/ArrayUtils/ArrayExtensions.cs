namespace OmegaCore.ArrayUtils
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public static class ArrayExtensions
    {
        private static readonly IArrayUtil _instance = new ArrayUtil();

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.IncreaseCapacity{T}(T[], int)"/>
        /// </summary>
        public static T[] IncreaseCapacity<T>(this T[] source, int newSize) => _instance.IncreaseCapacity(source, newSize);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.OmegaCopy{T}(T[], T[], int, int)"/>
        /// </summary>
        /// <exception cref="Exceptions.ArgumentCheckerException"/>
        public static void OmegaCopy<T>(this T[] source, T[] destination, int startIndex, int endIndex) => _instance.OmegaCopy(source, destination, startIndex, endIndex);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Shift{T}(T[], int, int)"/>
        /// </summary>
        /// <exception cref="Exceptions.ArgumentCheckerException"/>
        public static void Shift<T>(this T[] source, int initIndex, int endIndex) => _instance.Shift(source, initIndex, endIndex);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Shift{T}(T[], int, int)"/>
        /// </summary>
        /// <exception cref="Exceptions.ArgumentCheckerException"/>
        public static void Shift<T>(this T[] source, int initIndex) => _instance.Shift(source, initIndex, source.Length - 1);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.IndexOf{T}(T[], T)"/>
        /// </summary>
        public static int IndexOf<T>(this T[] source, T item) => _instance.IndexOf(source, item);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Clear{T}(T[], int)"/>
        /// </summary>
        public static void Clear<T>(this T[] source, int count = 0) => _instance.Clear(source, count);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Reverse{T}(T[], int)"/>
        /// </summary>
        public static void Reverse<T>(this T[] source, int count = 0) => _instance.Reverse(source, count);

        /// <summary>
        /// <inheritdoc cref="IArrayUtil.Swap{T}(T[], int, int)"/>
        /// </summary>
        public static void Swap<T>(this T[] source, int sourceIndex, int destinationInex) => _instance.Swap(source, sourceIndex, destinationInex);
    }
}