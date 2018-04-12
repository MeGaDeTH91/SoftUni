namespace P03_DependencyInversion.Models
{
    using System;

    public abstract class Strategy
    {
        public abstract int Calculate(int firstOperand, int secondOperand);
    }
}
