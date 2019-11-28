using System;

namespace Algorithms.Interfaces
{
	public interface IDefaultComparator<T>
	{
		Comparison<T> Comparator { get;  }
	}
}
