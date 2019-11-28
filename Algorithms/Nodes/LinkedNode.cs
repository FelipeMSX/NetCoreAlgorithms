using Algorithms.Abstracts;

 namespace Algorithms.Nodes
{
	/// <summary>
	/// Classe que representa uma estrutura com um ponteiro além de armazenar um objeto qualquer.
	/// </summary>
	/// <author>Felipe Morais</author>
	/// <email>felipemsx18@gmail.com</email>
	/// <typeparam name="E"></typeparam>
	public class LinkedNode<T> : NodeBase<T>
	{
		/// <summary>
		/// Representa um ponteiro para um node posterior.
		/// </summary>
		public LinkedNode<T> Next { get; set; }

		public LinkedNode() : base()
		{
		}

		/// <summary>
		/// Construtor padrão que inicializa o objeto.
		/// </summary>
		/// <param name="obj">Objeto genérico que será armazenado no node.</param>
		public LinkedNode(T obj) : base(obj)
		{
		}

		/// <summary>
		/// Avalia se existe um próximo node.
		/// </summary>
		/// <returns>Retorna true se existir um próximo node, caso contrário, false.</returns>
		public bool HasNext() => Next != null;
		
	}
}
