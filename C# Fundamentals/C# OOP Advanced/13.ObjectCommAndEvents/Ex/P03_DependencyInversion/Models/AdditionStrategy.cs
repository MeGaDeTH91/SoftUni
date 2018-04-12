namespace P03_DependencyInversion.Models
{
	public class AdditionStrategy : Strategy
    {
        public override int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
