namespace Algorithms.Interfaces
{
	interface ICommon<T>
	{
        bool Empty();
		T First();
		T Last();
		T Retrive(T obj);
        void Clear();
    }
}
