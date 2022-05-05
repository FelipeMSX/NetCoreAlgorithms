using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Abstracts;
using Algorithms.Exceptions;
using Algorithms.Interfaces;
using Algorithms.Nodes;
using Algorithms.Helpers;
using Algorithms.Collections.TreeTraversalStrategies;

namespace Algorithms.Collections.Dynamic
{
    public class BinaryTreeCollection<TValue> : SearchTreeBase<TValue, TreeSearchNode<TValue>>
    {

    


        public BinaryTreeCollection(Comparison<TValue> comparator) : base(comparator, new InOrderTraversalStrategy())
        {
            Root = new TreeSearchNode<TValue>();
        }

        public BinaryTreeCollection(Comparison<TValue> comparator, ITraversalStrategy traversalStrategy) : base(comparator, traversalStrategy)
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
                if (Comparator.Check(searchNode.Value, value) == ComparisonResult.Greater)
                    searchNode.Left = newNode;
                else if (Comparator.Check(searchNode.Value, value) == ComparisonResult.Lesser)
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
            removeNode.Value = default(TValue);

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
