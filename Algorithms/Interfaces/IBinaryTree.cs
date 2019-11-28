using Algorithms.Nodes;

namespace Algorithms.Interfaces
{
    public interface IBinaryTree<T>
    {
        BinaryNode<T> Root { get; protected set; }
        int Length { get; set; }
        void Insert(T value);
        T Remove(T value);
        T Retrieve(T value);
        bool Empty();

    }
}
