
namespace OmegaCore.Extensions
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public interface IArrayExtensions
    {

        T[] IncreaseCapacity<T>(T[] source, int newSize);
        void OmegaCopy<T>(T[] source, T[] destination, int startIndex, int endIndex);
        void Shift<T>(T[] source, int initIndex, int endIndex);
        int IndexOf<T>(T[] source, T item);
        void Clear<T>(T[] source, int count = 0);
        void Reverse<T>(T[] source, int count = 0);
        void Swap<T>(T[] source, int sourceIndex, int destinationIndex);

    }

    public class InternalArrayExtensions : IArrayExtensions
    {
        public T[] IncreaseCapacity<T>(T[] source, int newSize)
        {
            T[] newSource = new T[newSize];

            OmegaCopy(source, newSource, 0, source.Length - 1);

            return newSource;
        }

        public void OmegaCopy<T>(T[] source, T[] destination, int startIndex, int endIndex)
        {
            int count = endIndex - startIndex;
            if (destination.Length < count || source.Length < count)
                throw new ArgumentException("The destination array should has a size greater or equals than source");


            for (int i = startIndex; i <= endIndex; i++)
                destination[i] = source[i];
        }

        public void Shift<T>(T[] source, int initIndex, int endIndex)
        {
            if (initIndex > endIndex)
                throw new ArgumentException("Init should be greater than End");
            if (source.Length < initIndex || source.Length < endIndex)
                throw new ArgumentException("Init or End is out of range in the source collection");


            for (int i = initIndex; i < endIndex; i++)
                source[i] = source[i + 1];

            source[endIndex] = default!;
        }

        public void Clear<T>(T[] source, int count = 0)
        {
            int index = RetrieveArrayCount(source, count);

            for (int i = 0; i < index; i++)
                source[i] = default!;
        }

        public int IndexOf<T>(T[] source, T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            int index = 0;

            while (index < source.Length)
            {
                if (item.Equals(source[index]))
                    return index;

                index++;
            }

            return -1;
        }

        public void Reverse<T>(T[] source, int count = 0)
        {
            int arrayLenght = RetrieveArrayCount(source, count);
            int middleIndex = arrayLenght / 2;

            for (int i = 0; i < middleIndex; i++)
                Swap(source, i, arrayLenght - 1 - i);
        }

        public void Swap<T>(T[] source, int sourceIndex, int destinationIndex)
        {
            (source[destinationIndex], source[sourceIndex]) = (source[sourceIndex], source[destinationIndex]);
        }


        private static int RetrieveArrayCount<T>(T[] source, int count) => count == 0 ? source.Length : count;
    }

    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// TO-DO: Finds out a way to make the Instance not public or accessible. This is a work around to enable mocking in tests.
        /// </summary>
        public static IArrayExtensions Instance { get; set; } = new InternalArrayExtensions();

        /// <summary>
        /// Increases the size of the array based on newSize parameter.
        /// </summary>
        public static T[] IncreaseCapacity<T>(this T[] source, int newSize) => Instance.IncreaseCapacity(source, newSize);

        /// <summary>
        /// Copies the elements of the source array to the destination array.
        /// </summary>
        /// <exception cref="System.ArgumentException"/>
        public static void OmegaCopy<T>(this T[] source, T[] destination, int startIndex, int endIndex) => Instance.OmegaCopy(source, destination, startIndex, endIndex);

        /// <summary>
        /// Puts a default value in every position in the array, if you pass count will stop it when it reaches the count.
        /// </summary>
        public static void Clear<T>(this T[] source, int count = 0) => Instance.Clear(source, count);

        /// <summary>
        /// Shifts the items inside of array based on parameteres.
        /// <example>For example:
        /// <code>
        ///   int array = new int[5] {1, 2, 3, 4, 5};
        ///   array.shift(0,4);
        /// </code>
        /// results in an array {2, 3 , 4, 5, 0}.
        /// </example>
        /// <exception cref="System.ArgumentException"/>
        /// </summary>
        public static void Shift<T>(this T[] source, int initIndex, int endIndex) => Instance.Shift(source, initIndex, endIndex);

        /// <summary>
        /// Shifts the items inside of array based on parameteres.
        /// <example>For example:
        /// <code>
        ///   int array = new int[5] {1, 2, 3, 4, 5};
        ///   array.shift(2);
        /// </code>
        /// results in an array {1,2,3,5,0 }.
        /// </example>
        /// <exception cref="System.ArgumentException"/>
        /// </summary>
        public static void Shift<T>(this T[] source, int initIndex) => Instance.Shift(source, initIndex, source.Length - 1);

        /// <summary>
        /// Retrieves the position of the item inside of the array.
        /// </summary>
        /// <exception cref="System.ArgumentNullException"/>
        public static int IndexOf<T>(this T[] source, T item) => Instance.IndexOf(source, item);

        /// <summary>
        /// Changes the positions of the elements in the array.
        /// </summary>
        public static void Swap<T>(this T[] source, int sourceIndex, int destinationInex) => Instance.Swap(source, sourceIndex, destinationInex);

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
        public static void Reverse<T>(this T[] source, int count = 0) => Instance.Reverse(source, count);

    }
}