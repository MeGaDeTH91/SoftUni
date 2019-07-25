namespace _01.Sorting
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            MergeSort<int>.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

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
                if (startIndex >= endIndex)
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
                if (IsLess(arr[middleIndex], arr[middleIndex + 1]))
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
                    }
                }
            }

            private static bool IsLess(T leftElement, T rightElement)
            {
                return leftElement.CompareTo(rightElement) < 0;
            }
        }

        public class QuickSort<T> where T : IComparable<T>
        {
            public static void Sort(T[] arr)
            {
                Sort(arr, 0, arr.Length - 1);
            }

            private static void Sort(T[] arr, int startIndex, int endIndex)
            {
                if (startIndex >= endIndex)
                {
                    return;
                }

                int partition = Partition(arr, startIndex, endIndex);
                Sort(arr, startIndex, partition - 1);
                Sort(arr, partition + 1, endIndex);
            }

            private static int Partition(T[] arr, int startIndex, int endIndex)
            {
                if (startIndex >= endIndex)
                {
                    return startIndex;
                }

                int leftIndex = startIndex;
                int rightIndex = endIndex + 1;

                while (true)
                {
                    while (IsLess(arr[++leftIndex], arr[startIndex]))
                    {
                        if (leftIndex >= endIndex)
                        {
                            break;
                        }
                    }
                    while (IsLess(arr[startIndex], arr[--rightIndex]))
                    {
                        if (rightIndex <= startIndex)
                        {
                            break;
                        }
                    }
                    if (leftIndex >= rightIndex)
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
}
