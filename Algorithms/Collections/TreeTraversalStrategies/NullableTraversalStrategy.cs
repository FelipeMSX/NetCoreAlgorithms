using System;
using System.Collections.Generic;
using Algorithms.Nodes;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    public class NullableTraversalStrategy<T> : ITraversalStrategy<T>
    {
        public IEnumerator<T> Traversal(TreeSearchNode<T> node)
        {
            yield break; 
        }
    }
}
