using Algorithms.Nodes;
using System.Collections.Generic;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    public interface ITraversalStrategy<T>
    {
        IEnumerator<T> Traversal(TreeSearchNode<T> node);
    }
}
