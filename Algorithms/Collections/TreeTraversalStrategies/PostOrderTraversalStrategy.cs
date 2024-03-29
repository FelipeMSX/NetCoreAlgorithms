﻿using Algorithms.Abstracts;
using Algorithms.Helpers;
using Algorithms.Nodes;
using System.Collections.Generic;

namespace Algorithms.Collections.TreeTraversalStrategies
{
    //Postorder (Left, Right, Root)
    public class PostOrderTraversalStrategy : ITraversalStrategy
    {
        public IEnumerator<T> Traversal<T>(TreeSearchNode<T> node)
        {
            QueueStackBase<TreeSearchNode<T>> stack = new Static.Stack<TreeSearchNode<T>>(1000, ComparatorHelper.EmptyComparison);

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
