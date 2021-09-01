using Algorithms.Abstracts;
using Algorithms.Collections.Dynamic;
using Algorithms.Helpers;
using Algorithms.Nodes;
using System.Collections.Generic;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    //Inorder(Left, Root, Right) Depth-First Search (DFS) variation
    public class InOrderTraversal<T> : ITraversalStrategy<T>
    {
        public IEnumerator<T> Traversal(TreeSearchNode<T> node)
        {
            Dynamic.LinkedList<TreeSearchNode<T>> linkedList = new Dynamic.LinkedList<TreeSearchNode<T>>(ComparatorHelper.EmptyComparison);

            while(linkedList.Count > 0 || node != null)
            {
                if(node != null)
                {
                    linkedList.Add(node);
                    node = node.Left;
                }
                else
                {
                    node = linkedList.RemoveLast();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
    }
}
