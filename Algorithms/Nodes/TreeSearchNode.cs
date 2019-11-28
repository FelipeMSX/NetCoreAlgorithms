using Algorithms.Abstracts;

namespace Algorithms.Nodes
{
	public class TreeSearchNode<T> : NodeBase<T>
	{
		/// <summary>
		/// Representa um ponteiro para um node anterior.
		/// </summary>
		public TreeSearchNode<T> Left { get; set; }

		/// <summary>
		/// Representa um ponteiro para um node posterior.
		/// </summary>
		public TreeSearchNode<T> Right { get; set; }

		/// <summary>
		/// Representa um ponteiro para um node pai.
		/// </summary>
		public TreeSearchNode<T> Parent { get; set; }

		public TreeSearchNode() : base()
		{
		}

		/// <param name="obj">Objeto genérico que será armazenado no node.</param>
		public TreeSearchNode(T obj) : base(obj)
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
		/// <returns>Retorna true se existir um node superior, caso contrário, false.</returns>
		public bool HasFather() => Parent != null;
	}
}
