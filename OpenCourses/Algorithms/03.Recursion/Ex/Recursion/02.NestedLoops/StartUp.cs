namespace _02.NestedLoops
{
    using System;

    public class StartUp
    {
        private static int[] resultArr;

        public static void Main()
        {
            int loopCount = int.Parse(Console.ReadLine());
            resultArr = new int[loopCount];

            PrintLoops(0, loopCount);
        }

        private static void PrintLoops(int index, int loopCount)
        {
            if(index == loopCount)
            {
                Console.WriteLine(string.Join(" ", resultArr));
            }
            else
            {
                for (int i = 1; i <= loopCount; i++)
                {
                    resultArr[index] = i;
                    PrintLoops(index + 1, loopCount);
                }
            }
        }
    }
}
