using System;
using System.Collections;
using Algorithms.Exceptions;
using Algorithms.Helpers;
using Algorithms.Nodes;

namespace Algorithms.Collections
{

    /// <summary>
    /// This collection represents a descending ordered list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

                //Checks if the new node must be the first;
                if (Comparator.Check(search.Value, item) >= ComparisonResult.Equal)
                {
                    newNode.Next = Head.Next;
                    Head.Next   = newNode;
                }
                else
                {
                    while (search != null)
                    {
                        //Valida se é permitido objetos iguais na coleção.
                        if (Comparator.Check(search.Value, item) == ComparisonResult.Equal && !AllowEquals)
                            throw new EqualsElementException();

                        if (Comparator.Check(search.Value, item) >= ComparisonResult.Equal)
                        {
                            newNode.Next = search;
                            break;
                        }
                        previous = search;
                        search = search.Next;
                    }
                    previous.Next = newNode;
                }
			}
			Count++;
		}
    }
}
