using System;
using System.Collections.Generic;
using Algorithms.Abstracts;
using Algorithms.Exceptions;
using Algorithms.Helpers;
using Algorithms.Nodes;

namespace Algorithms.Collections.Dynamic
{
	/// <summary>
	/// Inserts the element in the beginning of the collection. The last element is in the end of the collection.
	/// Removes the object in the head, the last one inserted will be the first one to be removed. 
	/// </summary>
	public class LinkedList<T> : LinkedListBase<T, LinkedNode<T>>
	{
		public LinkedList(Comparison<T> comparator) : base(comparator)
		{
			Head = new LinkedNode<T>();
		}

		public override void Add(T item)
		{
			ValidateObject(item);

			LinkedNode<T> newNode = new LinkedNode<T>(item);

			if (IsEmpty())
				InsertNodeToEmptyList(newNode);
			else
				InsertNodeBefore(Head.Next, newNode);
		}

		public override bool Remove(T item)
		{
			ValidateObject(item);
			CheckEmptyCollection();

			//Removes the node from the head
			if (Comparator.Check(Head.Next.Value, item) == ComparisonResult.Equal)
			{
				RemoveNodeFromList(Head);
			}
			//Caso quando a coleção possui vários elementos e é preciso procurar o elemento.
			else
			{
				LinkedNode<T> previous = SearchPreviousPosition(item);

				if (previous != null)
					RemoveNodeFromList(previous);
				else
					throw new ElementNotFoundException();
			}

			return true;
		}

		public override T Retrieve(T item)
		{
			CheckEmptyCollection();
			ValidateObject(item);

			LinkedNode<T> current = Head.Next;

			while (current.HasNext() && Comparator.Check(current.Value, item) != ComparisonResult.Equal)
			{
				current = current.Next;
			}

			return Comparator.Check(current.Value, item) == ComparisonResult.Equal ? current.Value : default;
		}


		public override T First()
		{
			CheckEmptyCollection();

			return Head.Next.Value;
		}

		public override T Last()
		{
			CheckEmptyCollection();

			LinkedNode<T> current = Head.Next;

			while (current.HasNext())
				current = current.Next;

			return current.Value;
		}

		public override IEnumerator<T> GetEnumerator()
		{
			LinkedNode<T> current = Head;

			while (current.HasNext())
			{
				current = current.Next;
				yield return current.Value;

			}
		}

		public override bool RemoveFirst()
		{
			CheckEmptyCollection();

			RemoveNodeFromList(Head);

			return true;
		}

		public override bool RemoveLast()
		{
			CheckEmptyCollection();

			RemoveNodeFromList(SearchPreviousPosition(LastNode.Value));

			return true;
		}

		public override void AddLast(T item)
		{
			throw new NotImplementedException();
		}

		private T RemoveNodeFromList(LinkedNode<T> previousNode)
        {
            LinkedNode<T> currentNodeToRemove = previousNode.Next;
			AdjustLastNode(previousNode, currentNodeToRemove);
            previousNode.Next = currentNodeToRemove.Next;
			T Value = currentNodeToRemove.Value;
			currentNodeToRemove.Invalidate();
            Count--;

            return Value;
        }


		private void AdjustLastNode(LinkedNode<T> previousNode, LinkedNode<T> nextNode)
        {
			if (nextNode == LastNode)
				LastNode = previousNode;
		}

		private void InsertNodeToEmptyList(LinkedNode<T> newNode)
		{
			LastNode = newNode;
			Head.Next = newNode;
			Count++;
		}

		private void InsertNodeBefore(LinkedNode<T> node, LinkedNode<T> newNode)
		{
			newNode.Next = node;
			Head.Next = newNode;
			Count++;
		}

		private LinkedNode<T> SearchPreviousPosition(T objectKey)
        {
            LinkedNode<T> search = Head.Next;
            LinkedNode<T> previous = Head.Next;

            while (previous.HasNext())
            {
                if (Comparator.Check(search.Value, objectKey) == ComparisonResult.Equal)
                    return previous;

                previous = search;
                search = search.Next;
            }
            return null;
        }
    }
}
