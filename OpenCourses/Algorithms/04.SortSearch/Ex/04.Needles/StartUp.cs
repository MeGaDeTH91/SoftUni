namespace _04.Needles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string irrelevantLine = Console.ReadLine();

            List<int> resultList = new List<int>();

            int[] arr = Console.ReadLine()
                .Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] needles = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var needle in needles)
            {
                bool match = false;
                
                for (int index = 0; index < arr.Length; index++)
                {
                    if(arr[index] >= needle)
                    {
                        match = true;
                        int insertIndex = ReturnIndex(arr, index - 1);

                        resultList.Add(insertIndex);
                        break;
                    }
                }
                if (!match)
                {
                    int insertIndex = ReturnIndex(arr, arr.Length - 1);

                    resultList.Add(insertIndex);
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }

        private static int ReturnIndex(int[] arr, int checkIndex)
        {
            while (checkIndex >= 0)
            {
                if(arr[checkIndex] != 0)
                {
                    return checkIndex + 1;
                }
                checkIndex--;
            }
            return 0;
        }
    }
}
