namespace _02.QuickSort
{
    using System;

    public class QuickSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int startIndex, int endIndex)
        {
            if(startIndex >= endIndex)
            {
                return;
            }

            int partition = Partition(arr, startIndex, endIndex);
            Sort(arr, startIndex, partition - 1);
            Sort(arr, partition + 1, endIndex);
        }

        private static int Partition(T[] arr, int startIndex, int endIndex)
        {
            if(startIndex >= endIndex)
            {
                return startIndex;
            }

            int leftIndex = startIndex;
            int rightIndex = endIndex + 1;

            while (true)
            {
                while(IsLess(arr[++leftIndex], arr[startIndex]))
                {
                    if(leftIndex >= endIndex)
                    {
                        break;
                    }
                }
                while (IsLess(arr[startIndex], arr[--rightIndex]))
                {
                    if(rightIndex <= startIndex)
                    {
                        break;
                    }
                }
                if(leftIndex >= rightIndex)
                {
                    break;
                }
                Swap(arr, leftIndex, rightIndex);
            }
            Swap(arr, startIndex, rightIndex);
            return rightIndex;
        }

        private static void Swap(T[] arr, int leftIndex, int rightIndex)
        {
            T element = arr[leftIndex];
            arr[leftIndex] = arr[rightIndex];
            arr[rightIndex] = element;
        }

        private static bool IsLess(T leftElement, T rightElement)
        {
            return leftElement.CompareTo(rightElement) < 0;
        }
    }
}
