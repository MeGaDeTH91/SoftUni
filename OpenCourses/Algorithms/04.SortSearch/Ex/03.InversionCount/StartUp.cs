namespace _03.InversionCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int count = MergeSort.Sort(arr);

            Console.WriteLine(count);
            Console.WriteLine(string.Join(" ", arr));
        }

        public class MergeSort
        {
            private static int[] helpingArr;

            public static int Sort(int[] arr)
            {
                helpingArr = new int[arr.Length];
                return Sort(arr, 0, arr.Length - 1);
            }

            private static int Sort(int[] arr, int startIndex, int endIndex)
            {
                int invCount = 0;

                if (startIndex < endIndex)
                {
                    int middleIndex = (startIndex + endIndex) / 2;

                    Sort(arr, startIndex, middleIndex);
                    invCount += Sort(arr, middleIndex + 1, endIndex);

                    invCount+= Merge(arr, startIndex, middleIndex, endIndex);
                }

                return invCount;
            }

            private static int Merge(int[] arr, int startIndex, int middleIndex, int endIndex)
            {
                int invCount = 0;
                if (IsLess(arr[middleIndex], arr[middleIndex + 1]))
                {
                    return 0;
                }
                
                for (int index = startIndex; index <= endIndex; index++)
                {
                    helpingArr[index] = arr[index];
                }

                int leftIndex = startIndex;
                int rightIndex = middleIndex + 1;

                for (int checkIndex = startIndex; checkIndex <= endIndex; checkIndex++)
                {
                    if (leftIndex > middleIndex)
                    {
                        arr[checkIndex] = helpingArr[rightIndex++];
                    }
                    else if (rightIndex > endIndex)
                    {
                        arr[checkIndex] = helpingArr[leftIndex++];
                    }
                    else if (IsLess(helpingArr[leftIndex], helpingArr[rightIndex]))
                    {
                        arr[checkIndex] = helpingArr[leftIndex++];
                    }
                    else
                    {
                        arr[checkIndex] = helpingArr[rightIndex++];
                        invCount += ;
                    }
                }
                return invCount;
            }

            private static bool IsLess(int leftElement, int rightElement)
            {
                return leftElement.CompareTo(rightElement) < 0;
            }
        }
    }
}
