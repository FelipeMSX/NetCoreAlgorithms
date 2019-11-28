using Algorithms.Abstracts;

namespace Algorithms.Nodes
{
	public class BinaryNode<T> : NodeBase<T>
	{
		/// <summary>
		/// Representa um ponteiro para um node anterior.
		/// </summary>
		public BinaryNode<T> Left { get; set; }

		/// <summary>
		/// Representa um ponteiro para um node posterior.
		/// </summary>
		public BinaryNode<T> Right { get; set; }

		/// <summary>
		/// Representa um ponteiro para um node pai.
		/// </summary>
		public BinaryNode<T> Father { get; set; }

		public BinaryNode() : base()
		{
		}

		/// <param name="obj">Objeto genérico que será armazenado no node.</param>
		public BinaryNode(T obj) : base(obj)
		{
		}

		/// <summary>
		/// Avalia se existe um próximo node.
		/// </summary>
		/// <returns>Retorna true se existir um próximo node, caso contrário, false.</returns>
		public bool HasRight() => Right != null;

		/// <summary>
		/// Avalia se existe um node anterior ao atual.
		/// </summary>
		/// <returns>Retorna true se existir um node anterior, caso contrário, false.</returns>
		public bool HasLeft() => Left != null;

		/// <summary>
		/// Avalia se existe um node anterior ao atual.
		/// </summary>
		/// <returns>Retorna true se existir um node anterior, caso contrário, false.</returns>
		public bool HasFather() => Father != null;
	}
}
