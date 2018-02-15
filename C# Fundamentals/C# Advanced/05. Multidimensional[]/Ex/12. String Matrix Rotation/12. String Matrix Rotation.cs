using System;
using System.Collections.Generic;

namespace _12._String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string rotationDetail = Console.ReadLine();

            int startIndex = rotationDetail.IndexOf('(') + 1;
            int endIndex = rotationDetail.IndexOf(')');
            int length = endIndex - startIndex;
            rotationDetail = rotationDetail.Substring(startIndex, length);
            int degrees = int.Parse(rotationDetail) % 360;

            Queue<string> words = new Queue<string>();
                        
            int maxLength = 0;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                int currLength = command.Length;
                if(currLength > maxLength)
                {
                    maxLength = currLength;
                }
                words.Enqueue(command);
            }

            int rowCount = words.Count;
            int colCount = maxLength;

            string[][] matrix = new string[words.Count][];

            FillMatrixWithSpaces(ref matrix, rowCount, colCount);
            FillMatrixWithWords(ref matrix, rowCount, colCount, ref words);

            switch (degrees)
            {
                case 0:
                    PrintMatrix(matrix, rowCount, colCount);
                    break;
                case 90:
                    string[][] resultMatrix = new string[colCount][];
                    for (int rows = 0; rows < colCount; rows++)
                    {
                        resultMatrix[rows] = new string[rowCount];
                        for (int cols = 0; cols < rowCount; cols++)
                        {
                            resultMatrix[rows][cols] = matrix[rowCount - cols - 1][rows];
                        }
                    }
                    PrintMatrix(resultMatrix, rowCount, colCount);
                    break;
                case 180:
                    string[][] secondMatrix = new string[rowCount][];
                    for (int rows = 0; rows < rowCount; rows++)
                    {
                        secondMatrix[rows] = new string[colCount];
                        for (int cols = 0; cols < colCount; cols++)
                        {
                            secondMatrix[rows][cols] = matrix[rowCount - rows - 1][colCount - cols - 1];
                        }
                    }
                    PrintMatrix(secondMatrix, rowCount, colCount);
                    break;
                case 270:
                    string[][] thirdMatrix = new string[colCount][];
                    for (int rows = 0; rows < colCount; rows++)
                    {
                        thirdMatrix[rows] = new string[rowCount];
                        for (int cols = 0; cols < rowCount; cols++)
                        {
                            thirdMatrix[rows][cols] = matrix[cols][colCount - 1 - rows];
                        }
                    }
                    PrintMatrix(thirdMatrix, rowCount, colCount);
                    break;
                default:
                    break;
            }
        }

        private static void PrintMatrix(string[][] matrix, int rowCount, int colCount)
        {
            foreach (var m in matrix)
            {
                Console.WriteLine(string.Join("", m));
            }
        }

        private static void FillMatrixWithWords(ref string[][] matrix, int rowCount, int colCount, ref Queue<string> words)
        {
            
            for (int rows = 0; rows < rowCount; rows++)
            {
                string currWord = words.Dequeue();
                int step = currWord.Length;
                for (int cols = 0; cols < step; cols++)
                {
                    matrix[rows][cols] = currWord[cols].ToString();
                }
            }
        }

        private static void FillMatrixWithSpaces(ref string[][] matrix, int rowCount, int colCount)
        {
            for (int rows = 0; rows < rowCount; rows++)
            {
                matrix[rows] = new string[colCount];

                for (int cols = 0; cols < colCount; cols++)
                {
                    matrix[rows][cols] = " ";
                }
            }
        }
    }
}
