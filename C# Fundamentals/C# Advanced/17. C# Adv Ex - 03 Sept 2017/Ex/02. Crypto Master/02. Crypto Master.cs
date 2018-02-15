namespace _02._Crypto_Master
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                  .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();
            
            int maxSequence = 0;
            
            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    int currentIndex = index;
                    int nextIndex = (currentIndex + step) % numbers.Length;
                    int currMax = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                        currMax++;
                    }
                    if(currMax > maxSequence)
                    {
                        maxSequence = currMax;
                    }
                }
            }
            Console.WriteLine(maxSequence);
        }
    }
}
