using Algorithms.Nodes;
using System.Collections.Generic;

namespace Algorithms.Interfaces
{
    public interface ITraversalStrategy<T>
    {
        IEnumerator<T> Traversal(TreeSearchNode<T> node);
    }
}
