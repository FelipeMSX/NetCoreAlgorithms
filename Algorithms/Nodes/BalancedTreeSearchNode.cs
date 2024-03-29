﻿namespace Algorithms.Nodes
{
    public class BalancedTreeSearchNode<T> : TreeSearchNode<T>
    {
        public int Height { get; set; }

        public BalancedTreeSearchNode() : base() { }

        /// <param name="obj">Objeto genérico que será armazenado no node.</param>
        public BalancedTreeSearchNode(T obj) : base(obj) { }
    }
}
