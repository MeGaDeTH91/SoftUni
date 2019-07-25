namespace _01.MergeSort
{
    using System;

    public class MergeSort<T> where T : IComparable
    {
        private static T[] helpingArr;

        public static void Sort(T[] arr)
        {
            helpingArr = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int startIndex, int endIndex)
        {
            if(startIndex >= endIndex)
            {
                return;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            Sort(arr, startIndex, middleIndex);
            Sort(arr, middleIndex + 1, endIndex);

            Merge(arr, startIndex, middleIndex, endIndex);
        }

        private static void Merge(T[] arr, int startIndex, int middleIndex, int endIndex)
        {
            if(IsLess(arr[middleIndex], arr[middleIndex + 1]))
            {
                return;
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
                else if(rightIndex > endIndex)
                {
                    arr[checkIndex] = helpingArr[leftIndex++];
                }
                else if(IsLess(helpingArr[leftIndex], helpingArr[rightIndex]))
                {
                    arr[checkIndex] = helpingArr[leftIndex++];
                }
                else
                {
                    arr[checkIndex] = helpingArr[rightIndex++];
                }
            }
        }

        private static bool IsLess(T leftElement, T rightElement)
        {
            return leftElement.CompareTo(rightElement) < 0;
        }
    }
}
