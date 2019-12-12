using System;
using System.Collections;
using Algorithms.Exceptions;
using Algorithms.Helpers;
using Algorithms.Nodes;

namespace Algorithms.Collections
{
	
	public class OrderedLinkedList<T> : LinkedList<T>
	{
		
        /// <summary>
        /// Allows the collection can accept equals elements.
        /// </summary>
		public bool AllowEquals { get; private set; }

		public OrderedLinkedList(Comparison<T> comparator, bool allowEquals = true) : base(comparator)
		{
			AllowEquals = allowEquals;	
		}

        /// <summary>
        /// Finds the correct position to insert the item.
        /// </summary>
        /// <param name="item">A new item for the collection.</param>
		public override void Add(T item)
		{
            
			if (item == null)
				throw new NullObjectException();

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
					if (Comparator.Check(search.Value, item) == ComparisonResult.Equal && !AllowEquals)
						throw new EqualsElementException();

					if (Comparator.Check(search.Value, item) >= ComparisonResult.Equal)
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
