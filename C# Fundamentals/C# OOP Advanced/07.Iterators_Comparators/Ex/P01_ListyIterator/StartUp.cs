using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        ListyIterator<string> listyIterator = new ListyIterator<string>();
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] commTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string currentCommand = commTokens[0];


            switch (currentCommand)
            {
                case "Create":

                    if (commTokens.Length > 1)
                    {
                        listyIterator = new ListyIterator<string>(commTokens.Skip(1).ToArray());
                    }
                    break;
                case "Move":
                    string moveResult = listyIterator.Move() ? "True" : "False";
                    Console.WriteLine(moveResult);
                    break;
                case "HasNext":
                    string hasResult = listyIterator.HasNext() ? "True" : "False";
                    Console.WriteLine(hasResult);
                    break;
                case "Print":
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    break;
                default:
                    break;
            }
        }
        
    }
}
