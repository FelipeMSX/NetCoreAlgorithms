using Algorithms.Abstracts;

namespace Algorithms.Nodes
{
	/// <summary>
	/// Represents a class with previous and next pointer.
	/// </summary>
	/// <author>Felipe Morais</author>
	/// <email>felipemsx18@gmail.com</email>
	/// <typeparam name="E"></typeparam>
	public class LinkedDoubleNode<T> : NodeBase<T>
	{
		/// <summary>
		/// 
		/// </summary>
		public LinkedDoubleNode<T> Previous { get; set; }

		/// <summary>
		/// </summary>
		public LinkedDoubleNode<T> Next { get; set; }

		public LinkedDoubleNode() : base(){}

		public LinkedDoubleNode(T obj) : base(obj) {}

		public bool HasNext() => Next != null;

		public bool HasPrevious() => Previous != null;

		public override void Invalidate() 
		{
			base.Invalidate();
			Next  = Previous = null;
		}
    }
}
