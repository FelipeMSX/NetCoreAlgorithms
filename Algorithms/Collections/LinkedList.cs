﻿using System;
using System.Collections.Generic;
using Algorithms.Abstracts;
using Algorithms.Exceptions;
using Algorithms.Helpers;
using Algorithms.Nodes;

namespace Algorithms.Collections
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

			LinkedNode<T> newNode;
			newNode = new LinkedNode<T>(item);

			if (IsEmpty())
				Head.Next = newNode;
			else
			{
				LinkedNode<T> searchNode = Head.Next;

				while (searchNode.HasNext())
					searchNode = searchNode.Next;
				
				searchNode.Next = newNode;		
			}
			Count++;
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
           
			return Comparator.Check(current.Value, item) == ComparisonResult.Equal ? current.Value : default(T);
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

        private T RemoveNodeFromList(LinkedNode<T> previousNode)
        {
            LinkedNode<T> current = previousNode.Next;
            previousNode.Next = current.Next;
            current.Next = null;
            Count--;
            return current.Value;
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
