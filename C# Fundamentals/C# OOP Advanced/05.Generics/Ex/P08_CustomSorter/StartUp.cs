using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        CustomList<string> currList = new CustomList<string>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] commTokens = command.Split();

            string currentCommand = commTokens[0];

            switch (currentCommand)
            {
                case "Add":
                    string addElement = commTokens[1];
                    currList.Add(addElement);
                    break;
                case "Remove":
                    int removeIndex = int.Parse(commTokens[1]);
                    currList.Remove(removeIndex);
                    break;
                case "Contains":
                    string seekElement = commTokens[1];
                    bool listContains = currList.Contains(seekElement);
                    if (listContains)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                    break;
                case "Swap":
                    int firstIndex = int.Parse(commTokens[1]);
                    int secondIndex = int.Parse(commTokens[2]);

                    currList.Swap(firstIndex, secondIndex);
                    break;
                case "Greater":
                    string checkGreater = commTokens[1];
                    int greaterElements = currList.CountGreaterThan(checkGreater);
                    Console.WriteLine(greaterElements);
                    break;
                case "Max":
                    Console.WriteLine(currList.Max());
                    break;
                case "Min":
                    Console.WriteLine(currList.Min());
                    break;
                case "Sort":
                    currList.Sort();
                    break;
                case "Print":
                    Console.WriteLine(string.Join(Environment.NewLine, currList));
                    break;
                default:
                    break;
            }
        }
    }
}
