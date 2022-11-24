using System.Diagnostics;

namespace OmegaCore.Helpers
{
    public static class ArrayHelpers
    {
        public static T[] IncreaseCapacity<T>(this T[] source, int newSize)
        {
            T[] newSource = new T[newSize];

            OmegaCopy(source, newSource);

            return newSource;
        }

        public static void OmegaCopy<T>(this T[] source, T[] destination)
        {
            if (destination.Length < source.Length)
                throw new ArgumentException("The destination array should has a size greater or equals than source");

            for (int i = 0; i < source.Length; i++)
                destination[i] = source[i];
        }

        public static void Shift<T>(this T[] source, int init, int end)
        {
            if(init >= end)
                throw new ArgumentException("Init should be greater than End");
            if (source.Length < init || source.Length < end)
                throw new ArgumentException("Init or End is out of range in the source collection");

            for (int i = init; i < end; i++)
                source[i] = source[i + 1];

            source[end] = default!;
        }

        public static void Shift<T>(this T[] source, int init)
        {
            Shift(source, init, source.Length - 1);
        }

        public static void Clear<T>(this T[] source, int count = 0)
        {
            int index = count == 0 ? source.Length: count;

            for (int i = 0; i < index; i++)
                source[i] = default!;
        }
    }
}
