using System;
using System.Collections.Generic;

namespace P09_CollHier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int removeOperations = int.Parse(Console.ReadLine());

            AddCollection<string> myAddColl = new AddCollection<string>();
            AddRemoveCollection<string> myAddRemoveColl = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            List<int> addIndexes = new List<int>();
            List<int> addRemoveIndexes = new List<int>();
            List<int> myListIndexes = new List<int>();

            for (int index = 0; index < input.Length; index++)
            {
                addIndexes.Add(myAddColl.Add(input[index]));
                addRemoveIndexes.Add(myAddRemoveColl.Add(input[index]));
                myListIndexes.Add(myList.Add(input[index]));
            }

            List<string> addRemoves = new List<string>();
            List<string> myListRemoves = new List<string>();

            for (int removeIndex = 0; removeIndex < removeOperations; removeIndex++)
            {
                addRemoves.Add(myAddRemoveColl.Remove());
                myListRemoves.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", addIndexes));
            Console.WriteLine(string.Join(" ", addRemoveIndexes));
            Console.WriteLine(string.Join(" ", myListIndexes));
            Console.WriteLine(string.Join(" ", addRemoves));
            Console.WriteLine(string.Join(" ", myListRemoves));
        }
    }
}
