namespace OmegaCore.Helpers
{
    public static class ArrayHelpers
    {
        public  static T[] IncreaseCapacity<T>(T[] source,int newSize)
        {
            T[] newSource = new T[newSize];

            for (int i = 0; i < source.Length; i++)
                newSource[i] = source[i];

            return newSource;
        }

        public static void Copy<T>(this T[] source, T[] destination) 
        { 

        }


        public static void Shift<T>(T[] source, int init, int end)
        {
            for (int i = init; i < end; i++)
                source[i] = source[i + 1];
        }

        public static void Shift<T>(T[] source, int init)
        {
           Shift(source, init, source.Length - 1);  
        }
    }
}
