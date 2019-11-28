using Algorithms.Abstracts;
using Algorithms.Collections;
using Algorithms.Interfaces;
using Algorithms.Nodes;
using System.Collections.Generic;

namespace Algorithms.Helpers.TreeHelpers
{
    //Inorder(Left, Root, Right)
    public class InOrderTraversal<T> : ITraversalStrategy<T>
    {
        public IEnumerator<T> Traversal(TreeSearchNode<T> node)
        {
            QueueStackBase<TreeSearchNode<T>> staticStack = new StaticStack<TreeSearchNode<T>>(1000);

            while(staticStack.Length > 0 || node != null)
            {
                if(node != null)
                {
                    staticStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = staticStack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
    }
}
