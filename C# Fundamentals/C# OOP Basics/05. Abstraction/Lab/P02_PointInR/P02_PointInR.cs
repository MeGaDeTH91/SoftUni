using System;
using System.Linq;

public class P02_PointInR
{
    static void Main(string[] args)
    {
        Rectangle ourRectangle = new Rectangle();

        int[] rectanglePoints = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int topLeftX = rectanglePoints[0];
        int topLeftY = rectanglePoints[1];
        int botRightX = rectanglePoints[2];
        int botRightY = rectanglePoints[3];
        ourRectangle.TopLeft.X = topLeftX;
        ourRectangle.TopLeft.Y = topLeftY;
        ourRectangle.BotRight.X = botRightX;
        ourRectangle.BotRight.Y = botRightY;

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int currX = tokens[0];
            int currY = tokens[1];
            Point currPoint = new Point(currX, currY);
            string result = ourRectangle.Contains(currPoint) ? "True" : "False";
            Console.WriteLine(result);
        }
    }
}

