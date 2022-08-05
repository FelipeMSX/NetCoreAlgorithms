using Core.Interfaces;

namespace Core.OmegaLINQ
{
    public static class OmegaLINQ
    {
        public static T First<T>(this INumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T element in collection)
            {
                if (predicate(element)) return element;
            }

            //TODO
            throw new Exception();
        }
    }

    public  class LINQ_Test
    {
        public LINQ_Test()
        {
            MyList<int> teste = new();
        }
    }
}

public class MyList<T> : INumerable<T>
{
    public T Current => throw new NotImplementedException();


    public INumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    INumerator INumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}