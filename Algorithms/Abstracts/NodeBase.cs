namespace Algorithms.Abstracts
{
	/// <summary>
	/// Classe que tem como função armazenar um objeto qualquer.
	/// </summary>
	/// <author>Felipe Morais</author>
	/// <email>felipemsx18@gmail.com</email>
	public abstract class NodeBase<T>
	{
		public T Value{ get; set; }

		protected NodeBase(T value)
		{
			Value = value;
		}

        protected NodeBase()
		{  
		}
	}
}
