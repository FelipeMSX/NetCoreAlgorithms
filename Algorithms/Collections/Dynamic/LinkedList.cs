using System;
using System.Collections.Generic;
using Algorithms.Abstracts;
using Algorithms.Exceptions;
using Algorithms.Helpers;
using Algorithms.Nodes;

namespace Algorithms.Collections.Dynamic
{

	public class LinkedList<T> : LinkedListBase<T, LinkedNode<T>>
	{
        public LinkedList(Comparison<T> comparator) : base(comparator)
        {
            Head = new LinkedNode<T>();
		}

		public override void Add(T item)
		{
			if (item == null)
				throw new NullObjectException();

			LinkedNode<T> newNode = new LinkedNode<T>(item);

			if (IsEmpty())
				InsertNodeToEmptyList(newNode);
			else
				InsertNodeBefore(Head.Next, newNode);
		}

		public override bool Remove(T item)
		{
			//Validações
			if (item == null)
				throw new NullObjectException();
			if (IsEmpty())
				throw new EmptyCollectionException();

			//Remoção na cabeça da coleção.
			if (Comparator.Check(Head.Next.Value, item) == ComparisonResult.Equal)
            {
                RemoveNodeFromList(Head);
                return true;
            }
            //Caso quando a coleção possui vários elementos e é preciso procurar o elemento.
            else
			{
                LinkedNode<T> previous = SearchPreviousPosition(item);

                if (previous != null)
                {
                    RemoveNodeFromList(previous);
                    return true;
                }
                else
                    throw new ElementNotFoundException();
            }
		}

		public override T Retrieve(T item)
		{
			if (IsEmpty())
				throw new EmptyCollectionException();
			if (item == null)
				throw new NullObjectException();

			LinkedNode<T> current = Head.Next;
			while (current.HasNext() && Comparator.Check(current.Value, item) != ComparisonResult.Equal)
			{
				current = current.Next;
			}
           
			return Comparator.Check(current.Value, item) == ComparisonResult.Equal ? current.Value : default;
		}

		
		public override T First()
		{
			//Validações
			if (IsEmpty())
				throw new EmptyCollectionException();

			return Head.Next.Value;
		}

		public override T Last()
		{
			if (IsEmpty())
				throw new EmptyCollectionException();

			LinkedNode<T> current = Head.Next;
			while (current.HasNext())
			{
				current = current.Next;
			}
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
            return current.Value;
        }


		private void AdjustLastNode(LinkedNode<T> previousNode, LinkedNode<T> nextNode)
        {
			if (nextNode == LastNode)
				LastNode = previousNode;
		}

		private void InsertNodeToEmptyList(LinkedNode<T> newNode)
		{
			Head.Next = newNode;
			Count++;
		}

		private void InsertNodeBefore(LinkedNode<T> node, LinkedNode<T> newNode)
		{
			newNode.Next = node;
			Head.Next = node;
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

        public override bool RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public override bool RemoveLast()
        {
            throw new NotImplementedException();
        }

        public override void AddLast(T item)
        {
            throw new NotImplementedException();
        }
    }
}
