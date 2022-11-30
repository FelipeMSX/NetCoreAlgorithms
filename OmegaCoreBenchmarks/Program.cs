using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using OmegaCore.Collections;
using OmegaCore.Helpers;
using OmegaCore.Interfaces;
using OmegaCore.OmegaLINQ;
using System.Security.Cryptography;

namespace MyBenchmarks
{
    [MemoryDiagnoser]
    public class OmegaEnumerableVsEnumerable
    {
        private const int N = 10000;
        private readonly int[] data;

        private readonly IOmegaEnumerable<int> _iOmegaEnumerable;
        private readonly IEnumerable<int> _iEnumerable;

        public OmegaEnumerableVsEnumerable()
        {
            data = new int[N];
            for (int i = 0; i < N; i++)
            {
                data[i] = new Random(42).Next();
            }

            _iOmegaEnumerable = new OmegaList<int>(data);
            _iEnumerable = new List<int>(data);

        }

        [Benchmark]
        public void OmegaEnumerable_Count() => _iOmegaEnumerable.Count();

        [Benchmark]
        public void Enumerable_Count() => _iEnumerable.Count();

        [Benchmark]
        public void OmegaEnumerable_Take() => _iOmegaEnumerable.Take(100);

        [Benchmark]
        public void Enumerable_Take() => _iEnumerable.Take(100);

        //[Benchmark]
        //public void OmegaEnumerable_FirstOrDefault() => _iOmegaEnumerable.FirstOrDefault((x) => x > 1000);

        //[Benchmark]
        //public void Enumerable_FirsOrDefault() => _iEnumerable.FirstOrDefault((x) => x > 1000);

        //[Benchmark]
        //public void OmegaEnumerable_ToArray() => _iOmegaEnumerable.ToArray();

        //[Benchmark]
        //public void Enumerable_ToArray() => _iEnumerable.ToArray();

        //[Benchmark]
        //public void OmegaArrayHelpers_Copy()
        //{
        //    int[] newArray = new int[N];
        //    data.OmegaCopy(newArray);
        //}

        //[Benchmark]
        //public void Array_Copy() {
        //    int[] newArray = new int[N];
        //    data.CopyTo(newArray, 0);
        //}

        //[Benchmark]
        //public void Garbagetest ()
        //{
        //    for (int i = 0; i < 1; i++)
        //    {
        //        GargabeObject obj =  new GargabeObject(2);
        //    }
        //}

        //[Benchmark]
        //public void Garbagetest_DoNothing()
        //{
        //    for (int i = 0; i < 1; i++)
        //    {
        //    }
        //}

        public class GargabeObject
        {
           public int Id { get; set; }
            public int Id2 { get; set; }


            public GargabeObject(int id)
            {
                Id = id;    
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<OmegaEnumerableVsEnumerable>();
        }
    }

    
}