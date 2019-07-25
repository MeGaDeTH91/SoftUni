namespace _08.Snakes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        private static char[] snake;
        private static HashSet<string> allPossibleSnakes = new HashSet<string>();
        private static HashSet<string> markedPaths = new HashSet<string>();
        private static HashSet<string> resultSnakes = new HashSet<string>();


        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            snake = new char[n];

            GenerateSnake(0, 0, 0, 'S');

            foreach (var snake in resultSnakes)
            {
                Console.WriteLine(snake);
            }

            Console.WriteLine($"Snakes count = {resultSnakes.Count}");
        }

        private static void GenerateSnake(int index, int row, int col, char direction)
        {
            if(index >= snake.Length)
            {
                string normalSnake = new string(snake);

                if (!allPossibleSnakes.Contains(normalSnake))
                {
                    MarkSnake();
                }
            }
            else
            {
                string currentPosition = $"{row} {col}";
                if (!markedPaths.Contains(currentPosition))
                {
                    snake[index] = direction;

                    markedPaths.Add(currentPosition);

                    GenerateSnake(index + 1, row, col + 1, 'R');
                    GenerateSnake(index + 1, row + 1, col, 'D');
                    GenerateSnake(index + 1, row, col - 1, 'L');
                    GenerateSnake(index + 1, row - 1, col, 'U');

                    markedPaths.Remove(currentPosition);
                }
            }
        }

        private static void MarkSnake()
        {
            string normalSnake = new string(snake);
            
            resultSnakes.Add(normalSnake);

            string flippedSnake = FlipSnake(normalSnake);
            string reversedSnake = ReverseSnake(normalSnake);
            string reversedFlippedSnake = FlipSnake(reversedSnake);

            for (int i = 0; i < 4; i++)
            {
                allPossibleSnakes.Add(normalSnake);
                normalSnake = RotateSnake(normalSnake);

                allPossibleSnakes.Add(flippedSnake);
                flippedSnake = RotateSnake(flippedSnake);

                allPossibleSnakes.Add(reversedSnake);
                reversedSnake = RotateSnake(reversedSnake);

                allPossibleSnakes.Add(reversedFlippedSnake);
                reversedFlippedSnake = RotateSnake(reversedFlippedSnake);
            }
        }

        private static string FlipSnake(string currentSnake)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < currentSnake.Length; i++)
            {
                switch (currentSnake[i])
                {
                    case 'U': sb.Append('D'); break;
                    case 'D': sb.Append('U'); break;
                    default:  sb.Append(currentSnake[i]);
                        break;
                }
            }

            return sb.ToString().Trim();
        }

        private static string ReverseSnake(string currentSnake)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('S');

            for (int i = currentSnake.Length - 1; i >= 1; i--)
            {
                sb.Append(currentSnake[i]);
            }

            return sb.ToString().Trim();
        }

        private static string RotateSnake(string currentSnake)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < currentSnake.Length; i++)
            {
                switch (currentSnake[i])
                {
                    case 'U': sb.Append('R'); break;
                    case 'R': sb.Append('D'); break;
                    case 'D': sb.Append('L'); break;
                    case 'L': sb.Append('U'); break;
                    default:
                        sb.Append(currentSnake[i]);
                        break;
                }
                
            }
            return sb.ToString().Trim();
        }
    }
}
