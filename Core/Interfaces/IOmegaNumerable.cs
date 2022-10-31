namespace Core.Interfaces
{
	public interface IOmegaNumerable<out T> : INumerable
	{
		new IOmegaNumerator<T> GetEnumerator();
	}

	public interface INumerable
    {
		INumerator GetEnumerator();
    }
}

