namespace P03_DependencyInversion.Models
{
	public class SubtractionStrategy : Strategy
    {
        public override int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
