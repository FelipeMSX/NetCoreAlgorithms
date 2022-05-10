namespace Core.Interfaces
{
	public interface INumerator<out T>: INumerator
	{
		new T Current {get;}
	}

	public interface INumerator
	{
		object Current { get; }

		bool MoveNext();
	}
}