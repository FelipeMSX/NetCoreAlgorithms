
namespace OmegaCore.Extensions
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public class ArrayUtil : IArrayUtil
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
}