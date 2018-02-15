using System;
using System.Linq;

namespace _02._Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Player singlePlayer = new Player();

            int[] fieldDimensions = Console.ReadLine()
                              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            int rowCount = fieldDimensions[0];
            int colCount = fieldDimensions[1];

            string[,] field = new string[rowCount, colCount];

            FillField(ref field, rowCount, colCount);

            MoveAcrossField(field, ref singlePlayer, rowCount, colCount);

            Console.WriteLine($"Turns {singlePlayer.TurnsMade}");
            Console.WriteLine($"Money {singlePlayer.Money}");
        }

        private static void MoveAcrossField(string[,] field, ref Player singlePlayer, int rowCount, int colCount)
        {
            for (int row = 0; row < rowCount; row++)
            {
                if(row % 2 == 0)
                {
                    for (int col = 0; col < colCount; col++)
                    {
                        string currentElement = field[row, col];
                        DealWithItBro(currentElement, row, col, ref singlePlayer);
                    }
                }
                else
                {
                    for (int col = colCount - 1; col >= 0; col--)
                    {
                        string currentElement = field[row, col];
                        DealWithItBro(currentElement, row, col, ref singlePlayer);
                    }
                }
            }
        }

        private static void DealWithItBro(string currentElement, int row, int col, ref Player singlePlayer)
        {            
            switch (currentElement)
            {
                case "H":
                    long oldCash = singlePlayer.Money;
                    singlePlayer.Money = 0;
                    singlePlayer.HotelsCount++;
                    Console.WriteLine($"Bought a hotel for {oldCash}. Total hotels: {singlePlayer.HotelsCount}.");
                    break;
                case "J":
                    int oldTurnCount = singlePlayer.TurnsMade;
                    singlePlayer.TurnsMade += 2;
                    singlePlayer.Money += 2 * (singlePlayer.HotelsCount * 10);
                    Console.WriteLine($"Gone to jail at turn {oldTurnCount}.");
                    break;
                case "F":

                    break;
                case "S":
                    int currProduct = (row + 1) * (col + 1);
                    long moneySpent = Math.Min(singlePlayer.Money, currProduct);
                    singlePlayer.Money -= moneySpent;
                    Console.WriteLine($"Spent {moneySpent} money at the shop.");
                    break;
                default:
                    break;
            }
            singlePlayer.Money += singlePlayer.HotelsCount * 10;
            singlePlayer.TurnsMade++;
        }

        private static void FillField(ref string[,] field, int rowCount, int colCount)
        {
            for (int row = 0; row < rowCount; row++)
            {
                string currInput = Console.ReadLine(); ;
                for (int col = 0; col < colCount; col++)
                {
                    field[row, col] = currInput[col].ToString();
                }
            }
        }
        public class Player
        {
            public long Money { get; set; } = 50;

            public int HotelsCount { get; set; } = 0;

            public int TurnsMade { get; set; }
        }
    }
}
