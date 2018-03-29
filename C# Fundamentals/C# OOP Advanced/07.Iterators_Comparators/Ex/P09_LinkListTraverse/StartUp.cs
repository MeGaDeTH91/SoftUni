using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        TraverseLinkedList<int> myList = new TraverseLinkedList<int>();
        List<int> resultList = new List<int>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] commTokens = Console.ReadLine().Split();

            string currentCommand = commTokens[0];
            int currentNumber = int.Parse(commTokens[1]);

            switch (currentCommand)
            {
                case "Add":
                    Node<int> addNode = new Node<int>(currentNumber);
                    if (myList.Count == 0)
                    {
                        myList = new TraverseLinkedList<int>(addNode);
                    }
                    else
                    {
                        myList.Add(currentNumber);
                    }
                    break;
                case "Remove":
                    if(myList.Count > 0)
                    {
                        myList.Remove(currentNumber);
                    }
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(myList.Count);
        foreach (var item in myList)
        {
            resultList.Add(item);   
        }
        Console.WriteLine(string.Join(" ", resultList));
    }
}
