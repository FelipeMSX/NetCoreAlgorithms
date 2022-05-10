namespace Core.Interfaces
{
    public interface IList<T> : ICollection<T>
    {
        T this[int index] { get; set; }
    }
}
