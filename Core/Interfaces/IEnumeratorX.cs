namespace Core.Interfaces
{
	public interface IEnumeratorX<out T>: IEnumeratorX
	{
		new T Current {get;}
	}

	public interface IEnumeratorX
	{
		object Current { get; }

		bool MoveNext();
	}
}