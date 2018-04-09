namespace P04_BubbleSortTest
{
    using NUnit.Framework;
    using P04_BubbleSort;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class BubbleSortTest
    {
        [Test]
        public void BubbleSortWithStringsShoudlWorkCorrectly()
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

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void BubbleSortWithIntegersShoudlWorkCorrectly()
        {
            int[] initialStringArray = new int[] { 3, 2, 1, 0, -1, -2 };

            Type bubbleType = typeof(Bubble<int>);

            Bubble<int> classInstance = (Bubble<int>)Activator.CreateInstance(bubbleType, new object[] { initialStringArray });

            MethodInfo sortMethod = bubbleType.GetMethod("Sort", BindingFlags.Instance | BindingFlags.Public);

            IReadOnlyCollection<int> actualList = (IReadOnlyCollection<int>)bubbleType.GetProperty("BubbleSortedList", BindingFlags.Instance | BindingFlags.Public).GetValue(classInstance);

            sortMethod.Invoke(classInstance, null);

            Array.Sort(initialStringArray);

            string expectedResult = string.Join(" ", initialStringArray);
            string actualResult = string.Join(" ", actualList);

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
