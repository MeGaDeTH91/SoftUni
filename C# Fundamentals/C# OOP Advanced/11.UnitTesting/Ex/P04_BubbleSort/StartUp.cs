namespace P04_BubbleSort
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    class StartUp
    {
        static void Main(string[] args)
        {
            string[] initialStringArray = new string[] { "Delta", "Charlie", "Beta", "Alpha" };

            Type bubbleType = typeof(Bubble<string>);

            Bubble<string> classInstance = (Bubble<string>)Activator.CreateInstance(bubbleType, new object[] { initialStringArray });

            MethodInfo sortMethod = bubbleType.GetMethod("Sort", BindingFlags.Instance | BindingFlags.Public);

            IReadOnlyCollection<string> actualList = (IReadOnlyCollection<string>)bubbleType.GetProperty("BubbleSortedList", BindingFlags.Instance | BindingFlags.Public).GetValue(classInstance);

            sortMethod.Invoke(classInstance, null);

            Array.Sort(initialStringArray);

            string expectedResult = string.Join(" ", initialStringArray);
            string actualResult = string.Join(" ", actualList);
        }
    }
}
