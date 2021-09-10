using Algorithms.Abstracts;
using Algorithms.Helpers;
using Algorithms.Nodes;
using System.Collections.Generic;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    //Postorder (Left, Right, Root)
    public class PostOrderTraversal<T> : ITraversalStrategy<T>
    {
        public IEnumerator<T> Traversal(TreeSearchNode<T> node)
        {
            QueueStackBase<TreeSearchNode<T>> stack = new Static.Stack<TreeSearchNode<T>>(TraversalStrategyHelper.DEFAULT_STACK_SIZE, ComparatorHelper.EmptyComparison);

            TreeSearchNode<T> lastNodeVisited = null;

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    TreeSearchNode<T> peekNode = stack.Peek();
                    if (peekNode.Right != null && lastNodeVisited != peekNode.Right)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        yield return peekNode.Value;
                        lastNodeVisited = stack.Pop();
                    }
                }
            }
        }
    }
}
