using System;
namespace AlgorithmsTests.DesignPatterns.CreationalPatterns.UseCases
{
    public abstract class OperationWithState
    {
        public Calculator Calculator { get; set; }

        public OperationWithState(Calculator calculator)
        {
            Calculator = calculator;
        }

        public abstract int Calc(int x, int y);
    }


    public class AddWithState : OperationWithState
    {

        public AddWithState(Calculator calculator):base(calculator)
        {
        }

        public override int Calc(int x, int y)
        {
            return x + y;
        }
    }

    public class MultiplyWithState : OperationWithState
    {
        public MultiplyWithState(Calculator calculator) : base(calculator)
        {
        }

        public override int Calc(int x, int y)
        {
            return x * y;
        }
    }

    public class SubWithState : OperationWithState
    {
        public SubWithState(Calculator calculator) : base(calculator)
        {
        }

        public override int Calc(int x, int y)
        {
            return x - y;
        }
    }
}

public class Calculator
{
    public string Version { get; set; }
}


