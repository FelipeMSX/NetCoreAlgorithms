using System.Collections.Generic;
using Algorithms.Helpers;
using Algorithms.Interfaces;
using Algorithms.Nodes;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    //Inorder(Left, Root, Right) Depth-First Search (DFS) variation
    public class InOrderTraversalStrategy : ITraversalStrategy
    {
        public IEnumerator<T> Traversal<T>(TreeSearchNode<T> node)
        {
            IInteracbleCollection<TreeSearchNode<T>> linkedList = new Dynamic.LinkedList<TreeSearchNode<T>>(ComparatorHelper.EmptyComparison);

            while(linkedList.Count > 0 || node != null)
            {
                if(node != null)
                {
                    linkedList.Add(node);
                    node = node.Left;
                }
                else
                {
                    node = linkedList.First();
                    linkedList.RemoveFirst();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
    }
}
