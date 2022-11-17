using OmegaCore.Abstracts;
using OmegaCore.Interfaces;
using System;

namespace OmegaCoreTests.Shared
{
    public static class HelpersTests
    {
        public static bool CheckArrayOrder<T>(T[] collection, IOmegaIteratorBase<T> iterator )
        {
            bool isInOrder = true;
            int count = 0;

            while (iterator.MoveNext() && isInOrder)
            {
                if (!iterator.Current.Equals(collection[count++]))
                    isInOrder = false;
            }

            return isInOrder;
        }

        public static bool CheckListOrder<T>(IOmegaList<T> list, IOmegaIteratorBase<T> iterator)
        {
            bool isInOrder = true;
            int index = 0;

            while (iterator.MoveNext() && isInOrder)
            {
                if (!list[index++].Equals(iterator.Current))
                    isInOrder = false;
            }

            return isInOrder;
        }
    }
}
 