namespace OmegaCore.Interfaces
{
	public interface IOmegaEnumerable<out T> : IOmegaEnumerable
	{
		new IOmegaEnumerator<T> GetEnumerator();
	}

	public interface IOmegaEnumerable
    {
		IOmegaEnumerator GetEnumerator();
    }
}

