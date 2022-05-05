using Algorithms.Nodes;
using System.Collections.Generic;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    public interface ITraversalStrategy
    {
        IEnumerator<T> Traversal<T>(TreeSearchNode<T> node);
    }
}
