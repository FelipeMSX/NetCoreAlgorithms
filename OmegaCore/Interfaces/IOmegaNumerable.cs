namespace OmegaCore.Interfaces
{
	public interface IOmegaNumerable<out T> : IOmegaNumerable
	{
		new IOmegaNumerator<T> GetEnumerator();
	}

	public interface IOmegaNumerable
    {
		IOmegaNumerator GetEnumerator();
    }
}

