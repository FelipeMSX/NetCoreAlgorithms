namespace OmegaCore.Interfaces
{
	public interface IOmegaNumerator<out T>: IOmegaNumerator, IDisposable
    {
		new T Current { get; }
	}

	public interface IOmegaNumerator
	{
		object Current { get; }

		bool MoveNext();
	}
}