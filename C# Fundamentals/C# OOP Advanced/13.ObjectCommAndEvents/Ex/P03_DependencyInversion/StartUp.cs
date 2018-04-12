namespace P03_DependencyInversion
{
    using P03_DependencyInversion.Models;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            PrimitiveCalculator primitiveCalculator = new PrimitiveCalculator();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commTokens = command.Split();

                string checkForModeChange = commTokens[0];

                if (checkForModeChange.Equals("mode"))
                {
                    primitiveCalculator.ChangeStrategy(commTokens[1].First());
                }
                else
                {
                    int leftOperand = int.Parse(checkForModeChange);
                    int rightOperand = int.Parse(commTokens[1]);

                    Console.WriteLine(primitiveCalculator.PerformCalculation(leftOperand, rightOperand));
                }
            }
        }
    }
}
