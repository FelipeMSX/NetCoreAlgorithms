using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Test
{
    public class Shared
    {
        public const int DEFAULT_TIMEOUT = 3000;

        public static Comparison<int?> DefaultIntComparison { get; } = (x, y) =>
         {
             if (x > y)
                 return 1;
             else
             if (x < y)
                 return -1;
             else
                 return 0;
         };
    }
}

