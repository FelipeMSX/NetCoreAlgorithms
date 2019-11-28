using System;
using System.Collections;
using System.Collections.Generic;
using Algorithms.Exceptions;
using Algorithms.Interfaces;
using Algorithms.Nodes;

namespace Algorithms.Abstracts
{
	public abstract class SearchTreeBase<TValue, TNode> : ICollection<TValue>, IDefaultComparator<TValue>
		where TNode : TreeSearchNode<TValue>
	{
		public int Count { get; protected set; }
		public bool IsEmpty() => Count == 0;
		public bool IsReadOnly => false;
		public Comparison<TValue> Comparator { get; }

		/// <summary>
		/// Root não contém dados, é o "ponteiro" para o primeiro objeto da árvore.
		/// </summary>
		protected TNode Root { get; set; }
		protected ITraversalStrategy<TValue> TraversalStrategy { get; set; }
		protected TreeSearchNode<TValue> FirstNode
		{
			get => Root.Parent;
			set => Root.Parent = value;
		}

		protected SearchTreeBase(Comparison<TValue> comparator, ITraversalStrategy<TValue> traversalStrategy)
		{
			Comparator        = comparator ?? throw new NullObjectException("The comparison object cannot be null");
			TraversalStrategy = traversalStrategy ?? throw new NullObjectException("The traversal strategy object cannot be null"); ;
		}


		public abstract void Add(TValue value);
		public abstract bool Remove(TValue value);
		

		IEnumerator IEnumerable.GetEnumerator()
		{
            return GetEnumerator();
        }

		public IEnumerator<TValue> GetEnumerator()
		{
            return TraversalStrategy.Traversal(Root.Parent);

        }

		public TValue Retrieve(TValue item)
		{
			//Validações
			if (item == null)
				throw new NullObjectException();
			else if (IsEmpty())
				throw new EmptyCollectionException();

			TreeSearchNode<TValue> searchNode = FindNodeByValue(item);

			if (searchNode == null)
				throw new ElementNotFoundException();

			return searchNode.Value;
		}

		public void Clear()
		{
			Root = (TNode)new TreeSearchNode<TValue>();
			Count = 0;
		}

		public bool Contains(TValue item) => FindNodeByValue(item) != null;

		public void CopyTo(TValue[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Encontra a posição anterior ao valor informado. 
		/// Caso não encontre o nó com o valor retorna a posição mais próxima a ele.
		/// <para>Complexidade de Tempo: O(log n).</para>
		/// </summary>
		protected TreeSearchNode<TValue> FindPreviousNodeByValue(TValue item)
		{
			TreeSearchNode<TValue> searchNode = FirstNode;
			TreeSearchNode<TValue> previousNode = searchNode;
			bool positionFound = false;

			while (searchNode != null && !positionFound)
			{
				if (Comparator(item, searchNode.Value) < 0)
				{
					previousNode = searchNode;
					searchNode = searchNode.Left;
				}
				else if (Comparator(item, searchNode.Value) > 0)
				{
					previousNode = searchNode;
					searchNode = searchNode.Right;
				}
				else 
				{
					positionFound = true;// parar o loop.
				}
			}

			return positionFound ? searchNode : previousNode;
		}

		/// <summary>
		/// Encontra a posição do nó de acordo com o valor informado.
		/// <para>Complexidade de Tempo: O(log n).</para>
		/// </summary>
		/// <param name="item"></param>
		/// <returns>Retorna</returns>
		protected TreeSearchNode<TValue> FindNodeByValue(TValue item)
		{
			TreeSearchNode<TValue> searchNode = FirstNode;
			bool found = false;

			while (searchNode != null && !found)
			{
				if (Comparator(item, searchNode.Value) < 0)
				{
					searchNode = searchNode.Left;
				}
				else if (Comparator(item, searchNode.Value) > 0)
				{
					searchNode = searchNode.Right;
				}
				else 
				{
					found = true;
				}
			}

			return found ? searchNode : null;
		}


		protected TreeSearchNode<TValue> GoDeepToLeft(TreeSearchNode<TValue> node)
		{
			TreeSearchNode<TValue> foundNode = node;

			while (foundNode.HasLeft())
				foundNode = foundNode.Left;

			return foundNode;
		}

		/// <summary>
		/// Navega até não 
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		protected TreeSearchNode<TValue> GoDeepToRight(TreeSearchNode<TValue> node)
		{
			TreeSearchNode<TValue> foundNode = node;
			while (foundNode.HasRight())
				foundNode = foundNode.Right;

			return foundNode;
		}


		/// <summary>
		/// Remove a conexão de um determinado nó. Só é possível a remoção caso não tenha nenhum filho no nó.
		/// <para>Complexidade de Tempo: O(1).</para>
		/// </summary>
		/// <param name="node"></param>
		protected void EraseConnections(TreeSearchNode<TValue> node)
		{
			if (!node.HasLeft() && !node.HasRight())
			{
				if (node.Parent.Left == node)
					node.Parent.Left = null;
				else if (node.Parent.Right == node)
					node.Parent.Right = null;

				node.Parent = null;
			}
			else if (node.HasLeft() && !node.HasRight())
			{
				if (node.Parent.Left == node)
					node.Parent.Left = node.Left;
				else if (node.Parent.Right == node)
					node.Parent.Right = node.Left;

				node.Parent = null;
				node.Left = null;
			}
			else if (!node.HasLeft() && node.HasRight())
			{
				if (node.Parent.Left == node)
					node.Parent.Left = node.Right;
				else if (node.Parent.Right == node)
					node.Parent.Right = node.Right;

				node.Parent = null;
				node.Right = null;
			}
			else if (node.HasLeft() && node.HasRight())
			{
				TreeSearchNode<TValue> leftMostNode = GoDeepToLeft(node.Right);
				EraseConnections(leftMostNode);
				node.Value = leftMostNode.Value;
				leftMostNode.Value = default;
			}
		}
	}
}
