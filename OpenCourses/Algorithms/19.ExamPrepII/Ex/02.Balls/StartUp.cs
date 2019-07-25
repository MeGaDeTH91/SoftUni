namespace _02.Balls
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static int[] result;
        private static int pockets;
        private static int remainingPockets;
        private static int balls;
        private static int pocketCapacity;

        private static StringBuilder sb;

        public static void Main()
        {
            pockets = int.Parse(Console.ReadLine());
            remainingPockets = pockets;

            balls = int.Parse(Console.ReadLine());

            pocketCapacity = int.Parse(Console.ReadLine());

            result = new int[pockets];
            sb = new StringBuilder();

            Generate(0, balls);

            Console.WriteLine(sb.ToString().Trim());
        }
        private static void Generate(int index, int ballsRemaining)
        {
            if(index >= pockets)
            {
                if(ballsRemaining == 0)
                {
                    sb.AppendLine(string.Join(", ", result));
                }
            }
            else
            {
                int ballsToPut = ballsRemaining - (pockets - 1) + index;

                if(ballsToPut > pocketCapacity)
                {
                    ballsToPut = pocketCapacity;
                }
                for (int i = ballsToPut; i > 0; i--)
                {
                    result[index] = i;
                    Generate(index + 1, ballsRemaining - i);
                }
            }
        }
    }
}
