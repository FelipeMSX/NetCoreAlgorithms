using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Algorithms.Abstracts;
using Algorithms.Exceptions;

namespace Algorithms.Collections.Static
{

    /// <summary>
    /// Represents a stack and it was implemented using a vector.
    /// </summary>
    public class Stack<T> : QueueStackBase<T> 
	{
  
		public Stack(Comparison<T> comparator) : base(comparator)
		{
		}

        public Stack(int maxsize, Comparison<T> comparator, bool resizable = true) 
            : base (maxsize, comparator, resizable)
		{
		}

        /// <summary>
        /// Puts a item in the stack and putting a item in the end of the vector.
        /// </summary>
		public override void Push(T obj)
		{
            //Validações
            if (obj == null)
                throw new NullObjectException();
            if (Full() && !Resizable)
                throw new FullCollectionException();
            else
            if (Full())
            {
                IncreaseCapacity(DefaultSize);
            }

            Vector[Count++] = obj;
		}

        public async void TesteEnumerator()
        {
            //Arrange
            Queue<int?> _staticQueue = new Queue<int?>(100, (x,y) => 0);
            _staticQueue.Push(1);
            _staticQueue.Push(2);
            _staticQueue.Push(3);
            _staticQueue.Push(4);
            _staticQueue.Push(5);
            _staticQueue.Push(6);
            _staticQueue.Push(7);
            _staticQueue.Push(8);
            _staticQueue.Push(9);
            _staticQueue.Push(10);
            _staticQueue.Push(11);


            //Act

            // Create a task and supply a user delegate by using a lambda expression.
            Task taskA = new(() => {

                foreach (int item in _staticQueue)
                {
                    Console.WriteLine("TaskA int: " + item);
                }
            });

            Task taskB = new(() => {

                foreach (int item in _staticQueue)
                {
                    Console.WriteLine("TaskA int: " + item);
                }
            });


            await taskA;
            await taskB;

        }

        /// <summary>
        /// Removes the item in the top of the stack.
        /// </summary>
		public override T Pop()
		{
			if (Empty())
				throw new EmptyCollectionException();

			T temp = Vector[--Count];
			Vector[Count] = default(T);

			return temp;
		}

        /// <summary>
        /// Retrieves the item in the top of the stack without removing it.
        /// </summary>
        public override T Peek()
        {
            if (Empty())
                throw new EmptyCollectionException();

            return Vector[Count - 1];
        }

        public override T First() => Empty() ? default(T) : Vector[Count - 1];

        public override T Last() => Empty() ? default(T) : Vector[0];

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }
    }
}
