using System;
using System.Linq;

namespace _5._Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();

            int rowCount = sizes[0];
            int colCount = sizes[1];

            int[,] rubikMatrix = new int[rowCount, colCount];

            int startValue = 1;

            for (int rows = 0; rows < rowCount; rows++)
            {
                for (int cols = 0; cols < colCount; cols++)
                {
                    rubikMatrix[rows, cols] = startValue;
                    startValue++;
                }
            }

            int commandNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandNumber; i++)
            {
                string[] currentCommand = Console.ReadLine()
                                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

                int rowOrCol = int.Parse(currentCommand[0]);
                string direction = currentCommand[1];
                int times = int.Parse(currentCommand[2]);
                int lastElement = 0;

                switch (direction)
                {
                    case "left":
                        times = times % rowCount;
                        for (int timesCounter = 0; timesCounter < times; timesCounter++)
                        {
                            lastElement = rubikMatrix[rowOrCol, 0];
                            for (int index = 0; index < colCount - 1; index++)
                            {
                                rubikMatrix[rowOrCol, index] = rubikMatrix[rowOrCol, index + 1];
                            }
                            rubikMatrix[rowOrCol, colCount - 1] = lastElement;
                        }                       
                        break;
                    case "right":
                        times = times % rowCount;
                        for (int timesCounter = 0; timesCounter < times; timesCounter++)
                        {
                            lastElement = rubikMatrix[rowOrCol, colCount - 1];
                            for (int index = colCount - 1; index > 0 ; index--)
                            {
                                rubikMatrix[rowOrCol, index] = rubikMatrix[rowOrCol, index - 1];
                            }
                            rubikMatrix[rowOrCol, 0] = lastElement;
                        }                        
                        break;
                    case "up":
                        times = times % colCount;
                        for (int timesCounter = 0; timesCounter < times; timesCounter++)
                        {
                            lastElement = rubikMatrix[0, rowOrCol];
                            for (int index = 0; index < rowCount - 1; index++)
                            {
                                rubikMatrix[index, rowOrCol] = rubikMatrix[index + 1, rowOrCol];
                            }
                            rubikMatrix[rowCount - 1, rowOrCol] = lastElement;
                        }                        
                        break;
                    case "down":
                        times = times % colCount;
                        for (int timesCounter = 0; timesCounter < times; timesCounter++)
                        {
                            lastElement = rubikMatrix[rowCount - 1, rowOrCol];
                            for (int index = rowCount - 1; index > 0 ; index--)
                            {
                                rubikMatrix[index, rowOrCol] = rubikMatrix[index - 1, rowOrCol];
                            }
                            rubikMatrix[0, rowOrCol] = lastElement;
                        }                        
                        break;
                    default:
                        break;
                }                
            }

            int min = 1;

            for (int rows = 0; rows < rowCount; rows++)
            {
                for (int cols = 0; cols < colCount; cols++)
                {
                    if (rubikMatrix[rows, cols] == min)
                    {
                        Console.WriteLine("No swap required");
                        min++;
                    }
                    else
                    {
                        int seekRow = 0;
                        int seekCol = 0;
                        int oldValue = rubikMatrix[rows, cols];
                        int seekValue = 0;

                        for (int rowsSwap = rows; rowsSwap < rowCount; rowsSwap++)
                        {
                            for (int colsSwap = 0; colsSwap < colCount; colsSwap++)
                            {
                                if (rubikMatrix[rowsSwap, colsSwap] == min)
                                {
                                    seekRow = rowsSwap;
                                    seekCol = colsSwap;
                                    seekValue = rubikMatrix[seekRow, seekCol];
                                    rubikMatrix[seekRow, seekCol] = oldValue;
                                    rubikMatrix[rows, cols] = seekValue;
                                    break;
                                }
                            }
                        }
                        min++;
                        Console.WriteLine($"Swap ({rows}, {cols}) with ({seekRow}, {seekCol})");
                    }
                }
            }
        }
    }
}
