using Algorithms.Abstracts;

namespace Algorithms.Nodes
{
	public class BinaryNode<T> : NodeBase<T>
	{
		/// <summary>
		/// </summary>
		public BinaryNode<T> Left { get; set; }

		/// <summary>
		/// </summary>
		public BinaryNode<T> Right { get; set; }

		/// <summary>
		/// </summary>
		public BinaryNode<T> Parent { get; set; }

		public BinaryNode() : base()
		{
		}

		public BinaryNode(T obj) : base(obj)
		{
		}

		public bool HasRight() => Right != null;

		public bool HasLeft() => Left != null;

		public bool HasFather() => Parent != null;

		public override void Invalidate()
		{
			base.Invalidate();
			Right = Left = Parent = null;
		}
    }
}
