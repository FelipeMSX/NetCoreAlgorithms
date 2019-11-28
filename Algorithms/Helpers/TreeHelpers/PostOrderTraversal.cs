using Algorithms.Abstracts;
using Algorithms.Collections;
using Algorithms.Interfaces;
using Algorithms.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Helpers.TreeHelpers
{
    //Postorder (Left, Right, Root)
    public class PostOrderTraversal<T> : ITraversalStrategy<T>
    {
        public IEnumerator<T> Traversal(TreeSearchNode<T> node)
        {
            QueueStackBase<TreeSearchNode<T>> staticStack = new StaticStack<TreeSearchNode<T>>(1000);

            TreeSearchNode<T> lastNodeVisited = null;

            while (staticStack.Length > 0 || node != null)
            {
                if (node != null)
                {
                    staticStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    TreeSearchNode<T> peekNode = staticStack.Peek();
                    if (peekNode.Right != null && lastNodeVisited != peekNode.Right)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        yield return peekNode.Value;
                        lastNodeVisited = staticStack.Pop();
                    }
                }
            }
        }
    }
}
