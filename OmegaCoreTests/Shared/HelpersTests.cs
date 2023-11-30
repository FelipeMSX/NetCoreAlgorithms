using OmegaCore.Collections.Interfaces;
using OmegaCore.Iterators;
using System;

namespace OmegaCoreTests.Shared
{
    public static class HelpersTests
    {
        public static bool CheckArrayOrderOverIterator<T>(T[] collection, OmegaIteratorBase<T> iterator )
        {
            bool isInOrder = true;
            int count = 0;

            while (iterator.MoveNext() && isInOrder)
            {
                if (!iterator.Current!.Equals(collection[count++]))
                    isInOrder = false;
            }

            return isInOrder;
        }

        public static bool CheckListOrderOverIterator<T>(IOmegaList<T> list, OmegaIteratorBase<T> iterator)
        {
            bool isInOrder = true;
            int index = 0;

            while (iterator.MoveNext() && isInOrder)
            {
                if (!list[index++]!.Equals(iterator.Current))
                    isInOrder = false;
            }

            return isInOrder;
        }
    }
}
 