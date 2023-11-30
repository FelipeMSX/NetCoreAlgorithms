namespace OmegaCore.ArrayUtils
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

            Exceptions.ArgumentCheckerException.CheckSourceLessThanOther(destination.Length, count, nameof(destination.Length));
            Exceptions.ArgumentCheckerException.CheckSourceLessThanOther(source.Length, count, nameof(source.Length));

            for (int i = startIndex; i <= endIndex; i++)
                destination[i] = source[i];
        }

        public void Shift<T>(T[] source, int initIndex, int endIndex)
        {
            Exceptions.ArgumentCheckerException.CheckSourceGreaterThanOther(initIndex, endIndex, nameof(initIndex));
            Exceptions.ArgumentCheckerException.CheckSourceLessThanOther(source.Length, initIndex, nameof(source.Length));
            Exceptions.ArgumentCheckerException.CheckSourceLessThanOther(source.Length, endIndex, nameof(source.Length));

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
             Exceptions.ArgumentNullException.CheckAgainstNull(item,nameof(item));

            int index = 0;

            while (index < source.Length)
            {
                if (item!.Equals(source[index]))
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