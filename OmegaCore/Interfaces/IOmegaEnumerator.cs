namespace OmegaCore.Interfaces
{
	public interface IOmegaEnumerator<out T>: IOmegaEnumerator, IOmegaDisposable
    {
		new T Current { get; }
	}

	public interface IOmegaEnumerator
	{
		object Current { get; }

		bool MoveNext();

		void Reset();
	}
}