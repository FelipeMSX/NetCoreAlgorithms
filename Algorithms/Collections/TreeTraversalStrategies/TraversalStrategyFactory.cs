using Algorithms.DesignPatterns.CreationalPatterns.Factory;
using Algorithms.Nodes;
using System.Collections.Generic;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    public class TraversalStrategyFactory : AssemblyFactoryBase<ITraversalStorable>
    {
    }

    public abstract class ITraversalStorable : ITraversalStrategy<string>
    {
        public abstract IEnumerator<string> Traversal(TreeSearchNode<string> node);
    }

}
