namespace OmegaCore.Helpers
{
    public static class ArrayHelpers
    {
        public  static T[] IncreaseCapacity<T>(T[] source,int increment)
        {
            int newSize = increment + source.Length;
            T[] newSource = new T[newSize];

            for (int i = 0; i < source.Length; i++)
                newSource[i] = source[i];

            return newSource;
        }
    }
}
