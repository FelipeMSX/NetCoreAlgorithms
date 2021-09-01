using Algorithms.Abstracts;
using Algorithms.Helpers;
using Algorithms.Nodes;
using System.Collections.Generic;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    // Preorder (Root, Left, Right)
    public class PreOrderTraversalStrategy<T> : ITraversalStrategy<T>
    {
        public IEnumerator<T> Traversal(TreeSearchNode<T> node)
        {
            if(node == null)
            {
                yield break;
            }

            QueueStackBase<TreeSearchNode<T>> stack = new Static.Stack<TreeSearchNode<T>>(1000, ComparatorHelper.EmptyComparison);
            stack.Push(node);

            while (stack.Count > 0)
            {
                node = stack.Pop();

                yield return node.Value;

                if (node.Right != null)
                    stack.Push(node.Right);

                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }
    }
}
