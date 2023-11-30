namespace OmegaCore.ArrayUtils
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public interface IArrayUtil
    {
        /// <summary>
        /// Increases the size of the array based on newSize parameter.
        /// </summary>
        T[] IncreaseCapacity<T>(T[] source, int newSize);

        /// <summary>
        /// Copies the elements of the source array to the destination array.
        /// </summary>
        /// <exception cref="Exceptions.ArgumentCheckerException"/>
        void OmegaCopy<T>(T[] source, T[] destination, int startIndex, int endIndex);

        /// <summary>
        /// Shifts the items inside of array based on parameteres.
        /// <example>For example:
        /// <code>
        ///   int array = new int[5] {1, 2, 3, 4, 5};
        ///   array.shift(0,4);
        /// </code>
        /// results in an array {2, 3 , 4, 5, 0}.
        /// </example>
        /// </summary>
        /// <exception cref="Exceptions.ArgumentCheckerException"/>
        void Shift<T>(T[] source, int initIndex, int endIndex);

        /// <summary>
        /// Retrieves the position of the item inside of the array.
        /// </summary>
        /// <exception cref="Exceptions.ArgumentCheckerException"/>
        int IndexOf<T>(T[] source, T item);

        /// <summary>
        /// Puts a default value in every position in the array, if you pass count will stop it when it reaches the count.
        /// </summary>
        void Clear<T>(T[] source, int count = 0);

        /// <summary>
        /// Reverses all the elements in the array.
        /// <example>For example 01:
        /// <code>
        ///   int array = new int[5] {1, 2, 3, 4, 5};
        ///   array.reverse();
        /// </code>
        /// results in an array {5,4,3,2,1}.
        /// </example>
        /// <para>----------------------------------------</para>
        /// <example>For example 02:
        /// <code>
        ///   int array = new int[5] {1, 2, 3, 4, 5};
        ///   array.reverse(3);
        /// </code>
        /// results in an array {3,2,1,4,5}.
        /// </example>
        /// </summary>
        void Reverse<T>(T[] source, int count = 0);

        /// <summary>
        /// Changes the positions of the elements in the array.
        /// </summary>
        void Swap<T>(T[] source, int sourceIndex, int destinationIndex);
    }
}