using System;

namespace P02_NestedLoops
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] arr = new int[number];

            MakeNestedCombo(arr, 0);
        }

        private static void MakeNestedCombo(int[] arr, int index)
        {
            if(index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    int number = i + 1;
                    arr[index] = number;
                    MakeNestedCombo(arr, index + 1);
                }
            }
        }
    }
}
