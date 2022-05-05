using System;
using System.Collections.Generic;
using Algorithms.Nodes;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    public class NullableTraversalStrategy: ITraversalStrategy
    {
        public IEnumerator<T> Traversal<T>(TreeSearchNode<T> node)
        {
            yield break; 
        }
    }
}
