using Core.Interfaces;

namespace Core.OmegaLINQ
{
    public static class OmegaLINQ
    {
        public static T First<T>(this IOmegaNumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T element in collection)
            {
                if (predicate(element)) return element;
            }

            //TODO
            throw new Exception();
        }
    }

}