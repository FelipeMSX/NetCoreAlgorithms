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
    // Preorder (Root, Left, Right)
    public class PreOrderTraversal<T> : ITraversalStrategy<T>
    {
        public IEnumerator<T> Traversal(TreeSearchNode<T> node)
        {
            if(node == null)
            {
                yield break;
            }

            QueueStackBase<TreeSearchNode<T>> staticStack = new StaticStack<TreeSearchNode<T>>(1000);
            staticStack.Push(node);

            while (staticStack.Length > 0)
            {
                node = staticStack.Pop();

                yield return node.Value;

                if (node.Right != null)
                    staticStack.Push(node.Right);

                if (node.Left != null)
                    staticStack.Push(node.Left);
            }

        }
    }
}
