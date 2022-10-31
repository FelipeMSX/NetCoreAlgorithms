namespace Core.Interfaces
{
	public interface IOmegaNumerator<out T>: INumerator
	{
		new T Current { get; }
	}

	public interface INumerator
	{
		object Current { get; }

		bool MoveNext();
	}
}