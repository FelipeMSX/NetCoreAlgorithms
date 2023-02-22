using OmegaCore.Abstracts;
using OmegaCore.Interfaces;
using System;

namespace OmegaCoreTests.Shared
{
    public static class HelpersTests
    {

        public static bool CheckArrayOverArray<T>(T[] array01, T[] array02)
        {
            bool isInOrder = true;

            for (int i = 0; i < array01.Length; i++)
            {
                if (!array01[i]!.Equals(array02[i]!))
                    return false;
            }

            return isInOrder;
        }
        public static bool CheckArrayOrderOverIterator<T>(T[] collection, IOmegaIteratorBase<T> iterator )
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

        public static bool CheckListOrderOverIterator<T>(IOmegaList<T> list, IOmegaIteratorBase<T> iterator)
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
 