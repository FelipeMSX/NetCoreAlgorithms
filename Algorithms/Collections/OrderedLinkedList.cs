using System;
using Algorithms.Exceptions;
using Algorithms.Nodes;

namespace Algorithms.Collections
{
	
	public class OrderedLinkedList<T> : LinkedList<T>
	{
		
		public bool AllowEquals { get; private set; }

		public OrderedLinkedList(Comparison<T> comparator, bool allowEquals = true) : base(comparator)
		{
			Comparator = comparator;
			AllowEquals = allowEquals;	
		}

		public override void Add(T item)
		{
			if (item == null)
				throw new NullObjectException();
			if (Comparator == null)
				throw new ComparerNotSetException();

			LinkedNode<T> newNode = new LinkedNode<T>(item);
			if (IsEmpty())
			{
				Head.Next = newNode;
			} 
			else
			{
				LinkedNode<T> search = Head.Next;
				LinkedNode<T> previous = Head.Next;

				while (search != null)
				{
					//Valida se é permitido objetos iguais na coleção.
					if (Comparator(search.Value, item) == 0 && !AllowEquals)
						throw new EqualsElementException();

					if (Comparator(search.Value, item) >= 0)
					{
						previous.Next = newNode;
						newNode.Next = search;
						break;
					}
					previous = search;
					search = search.Next;
				}
				previous.Next = newNode;
			}
			Count++;
		}


    }
}
