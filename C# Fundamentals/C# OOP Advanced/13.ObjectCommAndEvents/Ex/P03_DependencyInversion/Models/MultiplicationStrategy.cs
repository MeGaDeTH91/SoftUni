namespace P03_DependencyInversion.Models
{
    using System;

    public class MultiplicationStrategy : Strategy
    {
        public override int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
