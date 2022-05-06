using System;
namespace Core.Interfaces
{
	public interface IEnumerableX<out T> : IEnumerableX
	{
		new IEnumeratorX<T> GetEnumerator();
	}

	public interface IEnumerableX
    {
		IEnumeratorX GetEnumerator();
    }
}

