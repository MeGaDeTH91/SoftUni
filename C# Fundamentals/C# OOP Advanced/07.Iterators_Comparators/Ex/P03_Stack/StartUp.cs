using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        CustomStack<string> theStack = new CustomStack<string>();

        string command;
        while((command = Console.ReadLine()) != "END")
        {
            string[] commTokens = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string currentCommand = commTokens[0];

            if (currentCommand.Equals("Push"))
            {
                theStack.Push(commTokens.Skip(1).ToArray());
            }
            else if (currentCommand.Equals("Pop"))
            {
                try
                {
                    theStack.Pop();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var element in theStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
