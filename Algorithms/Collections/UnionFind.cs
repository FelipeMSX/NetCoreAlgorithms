namespace Algorithms.Collections
{
    public class UnionFind
    {
        private readonly int[] _vector;

        /// <summary>
        /// Counts the amount of sets in the collection.
        /// </summary>
        public int Count { get; private set; }

        public UnionFind(int capacity)
        {
            _vector = new int[capacity];
            Count = capacity;

            for (int i = 0; i < capacity; i++)
                _vector[i] = i;
        }

        private int FindRoot(int q)
        {
            while (q != _vector[q])
                q = _vector[q];

            return q;
        }

        public void Union(int q, int p)
        {
            int i = FindRoot(p);
            int j = FindRoot(q);

            if (i != j)
            {
                _vector[i] = j;
                Count--;
            }
        }

        public bool IsConnected(int p, int q) => FindRoot(p) == FindRoot(q);
    }
}
