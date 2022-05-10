namespace Core.Interfaces
{
	public interface INumerable<out T> : INumerable
	{
		new INumerator<T> GetEnumerator();
	}

	public interface INumerable
    {
		INumerator GetEnumerator();
    }
}

