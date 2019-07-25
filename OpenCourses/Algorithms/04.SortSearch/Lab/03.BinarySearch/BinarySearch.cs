namespace _03.BinarySearch
{
    using System;

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
