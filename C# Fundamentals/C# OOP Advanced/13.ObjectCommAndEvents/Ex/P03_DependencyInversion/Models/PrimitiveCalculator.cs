using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_DependencyInversion.Models
{
    public class PrimitiveCalculator
    {
        private Strategy currentStrategy;
        private AdditionStrategy additionStrategy;
        private SubtractionStrategy subtractionStrategy;
        private MultiplicationStrategy multiplicationStrategy;
        private DivisionStrategy divisionStrategy;
        private Strategy[] strategies;

        public PrimitiveCalculator()
        {
            this.additionStrategy = new AdditionStrategy();
            this.subtractionStrategy = new SubtractionStrategy();
            this.multiplicationStrategy = new MultiplicationStrategy();
            this.divisionStrategy = new DivisionStrategy();
            this.strategies = new Strategy[] { this.additionStrategy, this.subtractionStrategy, this.multiplicationStrategy, this.divisionStrategy };
            this.currentStrategy = this.additionStrategy;
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator){
                case '+':
                    SetStrategy(this.additionStrategy.GetType().Name);
                    break;
                case '-':
                    SetStrategy(this.subtractionStrategy.GetType().Name);
                    break;
                case '*':
                    SetStrategy(this.multiplicationStrategy.GetType().Name);
                    break;
                case '/':
                    SetStrategy(this.divisionStrategy.GetType().Name);
                    break;
            }
        }

        private void SetStrategy(string strategyName)
        {
            var newStrategy = this.strategies.FirstOrDefault(x => x.GetType().Name.Equals(strategyName));

            this.currentStrategy = newStrategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.currentStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}
