using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Abstracts;
using Algorithms.Helpers.TreeHelpers;
using Algorithms.Exceptions;
using Algorithms.Interfaces;
using Algorithms.Nodes;

namespace Algorithms.Collections
{
    public class BinaryTreeCollection<TValue> : SearchTreeBase<TValue, TreeSearchNode<TValue>>
    {

        public BinaryTreeCollection(Comparison<TValue> comparator) : base(comparator, new InOrderTraversal<TValue>())
        {
            Root = new TreeSearchNode<TValue>();
        }

        public BinaryTreeCollection(Comparison<TValue> comparator, ITraversalStrategy<TValue> traversalStrategy) : base(comparator, traversalStrategy)
        {
            Root = new TreeSearchNode<TValue>();
        }

        public override void Add(TValue value)
        {
            TreeSearchNode<TValue> newNode = new TreeSearchNode<TValue>(value);

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
                TreeSearchNode<TValue> searchNode = FindPreviousNodeByValue(value);

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
            //Validações
            if (value == null || IsEmpty())
                return false;

            TreeSearchNode<TValue> removeNode = FindNodeByValue(value);

            if (removeNode == null)
                return false;

            //A partir daqui é pra remover o objeto.
            removeNode.Value = default;

            //Remover na Raiz
            if (Count == 1)
            {
                removeNode.Parent   = null;
                FirstNode           = null;
            }
            else
            {
                EraseConnections(removeNode);
            }

            Count--;

            return true;
        }

  
    }
}
