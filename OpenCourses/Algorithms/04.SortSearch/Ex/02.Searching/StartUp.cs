namespace _02.Searching
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

            int seekNum = int.Parse(Console.ReadLine());

            int elementIndex = BinarySearch.Find(numbers, seekNum);

            Console.WriteLine(elementIndex);
        }
        public class BinarySearch
        {
            public static int Find(int[] arr, int key)
            {
                int startIndex = 0;
                int endIndex = arr.Length - 1;

                while (startIndex <= endIndex)
                {
                    int mid = (startIndex + endIndex) / 2;

                    if (arr[mid] < key)
                    {
                        startIndex = mid + 1;
                    }
                    else if (arr[mid] > key)
                    {
                        endIndex = mid - 1;
                    }
                    else
                    {
                        return mid;
                    }
                }

                return -1;
            }
        }
    }
}
