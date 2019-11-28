using Algorithms.Abstracts;
using Algorithms.Helpers.TreeHelpers;
using Algorithms.Exceptions;
using Algorithms.Interfaces;
using Algorithms.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Collections
{
    public class BalancedTreeCollection<TValue> : SearchTreeBase<TValue, BalancedTreeSearchNode<TValue>>
    {
        public BalancedTreeCollection(Comparison<TValue> comparator) : base(comparator, new InOrderTraversal<TValue>())
        {
            Root = new BalancedTreeSearchNode<TValue>();
        }

        public BalancedTreeCollection(Comparison<TValue> comparator, ITraversalStrategy<TValue> traversalStrategy) : base(comparator, traversalStrategy)
        {
            Root = new BalancedTreeSearchNode<TValue>();
        }


        public override void Add(TValue value)
        {
            BalancedTreeSearchNode<TValue> newNode = new BalancedTreeSearchNode<TValue>(value);

            //Validações
            if (value == null)
                throw new NullObjectException();

            if (IsEmpty())
            {
                Root.Parent = newNode;
                Count++;
            }
            else
            {
                BalancedTreeSearchNode<TValue> searchNode = (BalancedTreeSearchNode<TValue>) FindPreviousNodeByValue(value);

                //Se chegar aqui deve ser inserido.
                if (Comparator(searchNode.Value, value) > 0)
                    searchNode.Left = newNode;
                else if (Comparator(searchNode.Value, value) < 0)
                    searchNode.Right = newNode;
                else
                    throw new EqualsElementException();

                newNode.Parent = searchNode;
                Count++;
            }

        }

        public override bool Remove(TValue value)
        {
            throw new NotImplementedException();
        }

        private void RightRotation(BalancedTreeSearchNode<TValue> root, BalancedTreeSearchNode<TValue> pivot)
        {
            root.Left          = pivot.Right;
            pivot.Right.Parent = root;
            pivot.Right        = root;
            pivot.Parent       = root.Parent;
            root.Parent        = pivot;
        }
        private void LeftRotation(BalancedTreeSearchNode<TValue> root, BalancedTreeSearchNode<TValue> pivot)
        {
            root.Right        = pivot.Left;
            pivot.Left.Parent = root;
            pivot.Left        = root;
            pivot.Parent      = root.Parent;
            root.Parent       = pivot;
        }
    }
}
