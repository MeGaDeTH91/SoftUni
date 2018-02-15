using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();


            string[] inputLine = Console.ReadLine()
                .Split(' ').ToArray();
            while (inputLine[0] != "print")
            {
                string command = inputLine[0];
                if(command == "add")
                {
                    int index = int.Parse(inputLine[1]);
                    int element = int.Parse(inputLine[2]);
                    list.Insert(index, element);
                }
                else if (command == "addMany")
                {
                    List<int> element = new List<int>();
                    int index = int.Parse(inputLine[1]);
                    for (int i = 2; i < inputLine.Length; i++)
                    {
                        int currElement = int.Parse(inputLine[i]);
                        element.Add(currElement);
                    }
                    list.InsertRange(index, element);
                }
                else if (command == "contains")
                {
                    int element = int.Parse(inputLine[1]);
                    int index = list.IndexOf(element);
                    Console.WriteLine(index);
                }
                else if (command == "remove")
                {
                    int index = int.Parse(inputLine[1]);
                    list.RemoveAt(index);
                }
                else if (command == "shift")
                {
                    int rotateCount = int.Parse(inputLine[1]);
                    for (int i = 0; i < rotateCount; i++)
                    {
                        list.Add(list[0]);
                        list.RemoveAt(0);
                    }
                }
                else if (command == "sumPairs")
                {
                    var currSum = new List<int>();
                    for (int i = 0; i < list.Count; i += 2)
                    {
                        var currentElement = list[i];
                        var nextElement = 0;
                        if(i < list.Count - 1)
                        {
                            nextElement = list[i + 1];
                        }
                        currSum.Add(currentElement + nextElement);
                    }
                    list = currSum;
                }
                inputLine = Console.ReadLine()
                .Split(' ').ToArray();
            }
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }
    }        
}
