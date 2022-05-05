using System;
namespace AlgorithmsTests.DesignPatterns.CreationalPatterns.UseCases
{
    public interface IOperation
    {
        public int Calc(int x, int y);
    }

    public class Add : IOperation
    {
        public int Calc(int x, int y)
        {
            return x + y;
        }
    }

    public class Multiply : IOperation
    {
        public int Calc(int x, int y)
        {
            return x * y;
        }
    }

    public class Sub : IOperation
    {
        public int Calc(int x, int y)
        {
            return x - y;
        }
    }

}