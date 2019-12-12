using System;

namespace Algorithms.Helpers
{
    public static class ComparatorHelper
    {
        public static ComparisonResult Check<T>(this Comparison<T> comparison, T itemX, T itemY)
        {
            int comparisonResult = comparison(itemX, itemY);
            if (comparisonResult > 0)
                return ComparisonResult.Greater;
            if (comparisonResult < 0)
                return ComparisonResult.Lesser;
            else
                return ComparisonResult.Equal;
        }

        public static Comparison<object> EmptyComparison = (x, y) => 0;
    }

    public enum ComparisonResult { Lesser, Equal, Greater }
}
