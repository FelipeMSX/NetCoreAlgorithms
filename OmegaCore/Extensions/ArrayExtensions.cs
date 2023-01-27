
namespace OmegaCore.Extensions
{
    public interface IArrayExtensions
    {
        T[] IncreaseCapacity<T>(T[] source, int newSize);
        void OmegaCopy<T>(T[] source, T[] destination, int length);
        void Shift<T>(T[] source, int init, int end);
        int IndexOf<T>(T[] source, T item);
        void Clear<T>(T[] source, int count = 0);
    }

    public class ArrayInternalExtensions : IArrayExtensions
    {
        public T[] IncreaseCapacity<T>(T[] source, int newSize)
        {
            T[] newSource = new T[newSize];

            OmegaCopy(source, newSource, newSource.Length);

            return newSource;
        }

        public void OmegaCopy<T>(T[] source, T[] destination, int length)
        {
            if (destination.Length < source.Length)
                throw new ArgumentException("The destination array should has a size greater or equals than source");

            for (int i = 0; i < source.Length && i < length; i++)
                destination[i] = source[i];
        }

        public void Shift<T>(T[] source, int init, int end)
        {
            if (init >= end)
                throw new ArgumentException("Init should be greater than End");
            if (source.Length < init || source.Length < end)
                throw new ArgumentException("Init or End is out of range in the source collection");

            for (int i = init; i < end; i++)
                source[i] = source[i + 1];

            source[end] = default!;
        }

        public void Clear<T>(T[] source, int count = 0)
        {
            int index = count == 0 ? source.Length : count;

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
    }

    public static class ArrayExtensions
    {
        public static IArrayExtensions Instance { get; set; } = new ArrayInternalExtensions();

        public static T[] IncreaseCapacity<T>(this T[] source, int newSize) => Instance.IncreaseCapacity(source, newSize);

        public static void OmegaCopy<T>(this T[] source, T[] destination, int length) => Instance.OmegaCopy(source, destination, length);

        public static void OmegaCopy<T>(this T[] source, T[] destination) => Instance.OmegaCopy(source, destination, source.Length);

        public static void Clear<T>(this T[] source, int count = 0) => Instance.Clear(source, count);

        public static void Shift<T>(this T[] source, int init, int end) => Instance.Shift(source, init, end);

        public static void Shift<T>(this T[] source, int init) => Instance.Shift(source, init, source.Length - 1);

        public static int IndexOf<T>(this T[] source, T item) => Instance.IndexOf(source, item);
    }
}