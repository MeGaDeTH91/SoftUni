using System;
using System.Numerics;

class InstructionSet_broken
{
    static void Main()
    {
        for (int i = 1; i <= 5; i++)
        {
            string opCode = Console.ReadLine();
            string[] codeArgs = opCode.Split(' ');
            if (codeArgs[0] == "END")
            {
                return;
            }
            BigInteger result = 0;
            switch (codeArgs[0])
            {
                case "INC":
                    {
                        BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                        operandOne++;
                        result = operandOne;
                        Console.WriteLine(result);
                        break;
                    }
                case "DEC":
                    {
                        BigInteger operandOne = BigInteger.Parse(codeArgs[1]);

                        operandOne--;
                        result = operandOne;
                        Console.WriteLine(result);
                        break;
                    }
                case "ADD":
                    {
                        BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                        BigInteger operandTwo = BigInteger.Parse(codeArgs[2]);
                        result = operandOne + operandTwo;
                        Console.WriteLine(result);
                        break;
                    }
                case "MLA":
                    {
                        BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                        BigInteger operandTwo = BigInteger.Parse(codeArgs[2]);

                        BigInteger multipl = operandOne * operandTwo;
                        Console.WriteLine(multipl);
                        break;
                    }
            }
        }
        

        
    }
}