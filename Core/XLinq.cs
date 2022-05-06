using Core.Interfaces;

namespace Core
{
    public static class XLinq
    {
        public static T First<T>(this IEnumerableX<T> collection, Func<T, bool> predicate)
        {
            foreach (T element in collection)
            {
                if (predicate(element)) return element;
            }
        }
    }

    public  class LINQ_Test
    {
        public LINQ_Test()
        {
            MyList<int> teste = new();
            teste.First(2);
        }
    }
}

public class MyList<T> : IEnumerableX<T>
{
    public IEnumeratorX<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumeratorX IEnumerableX.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}