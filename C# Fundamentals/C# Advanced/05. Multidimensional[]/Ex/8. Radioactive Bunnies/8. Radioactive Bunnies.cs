using System;

namespace _8._Radioactive_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Console.ReadLine().Trim().Split();
            var row = int.Parse(items[0]);
            var col = int.Parse(items[1]);

            var matr = new char[row, col];
            string input;
            var output = string.Empty;

            for (var i = 0; i < row; i++)
            {
                input = Console.ReadLine();
                for (var j = 0; j < col; j++)
                    matr[i, j] = input[j];
            }

            var resultingCave = new char[row, col];
            Array.Copy(matr, resultingCave, matr.Length);

            input = Console.ReadLine();
            bool died = false, escaped = false;

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < row; j++)
                {
                    for (var k = 0; k < col; k++)
                    {
                        if (!matr[j, k].Equals('P'))
                            continue;

                        switch (input[i])
                        {
                            case 'U':
                                try
                                {
                                    if (resultingCave[j - 1, k].Equals('B'))
                                    {
                                        output = $"dead: {j - 1} {k}";
                                        resultingCave[j, k] = '.';
                                        died = true;
                                    }
                                    else
                                    {
                                        resultingCave[j - 1, k] = 'P';
                                        resultingCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    output = $"won: {j} {k}";
                                    escaped = true;
                                    resultingCave[j, k] = '.';
                                }
                                break;

                            case 'L':
                                try
                                {
                                    if (resultingCave[j, k - 1].Equals('B'))
                                    {
                                        output = $"dead: {j} {k - 1}";
                                        resultingCave[j, k] = '.';
                                        died = true;
                                    }
                                    else
                                    {
                                        resultingCave[j, k - 1] = 'P';
                                        resultingCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    output = $"won: {j} {k}";
                                    escaped = true;
                                    resultingCave[j, k] = '.';
                                }
                                break;

                            case 'R':
                                try
                                {
                                    if (resultingCave[j, k + 1].Equals('B'))
                                    {
                                        output = $"dead: {j} {k + 1}";
                                        resultingCave[j, k] = '.';
                                        died = true;
                                    }
                                    else
                                    {
                                        resultingCave[j, k + 1] = 'P';
                                        resultingCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    output = $"won: {j} {k}";
                                    escaped = true;
                                    resultingCave[j, k] = '.';
                                }
                                break;

                            case 'D':
                                try
                                {
                                    if (resultingCave[j + 1, k].Equals('B'))
                                    {
                                        output = $"dead: {j + 1} {k}";
                                        resultingCave[j, k] = '.';
                                        died = true;
                                    }
                                    else
                                    {
                                        resultingCave[j + 1, k] = 'P';
                                        resultingCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    output = $"won: {j} {k}";
                                    escaped = true;
                                    resultingCave[j, k] = '.';
                                }
                                break;
                        }
                    }
                }
                for (var j = 0; j < row; j++)
                {
                    for (var k = 0; k < col; k++)
                    {
                        if (!matr[j, k].Equals('B'))
                            continue;

                        try
                        {
                            var element = resultingCave[j - 1, k];
                            if (element.Equals('P'))
                            {
                                died = true;
                                output = $"dead: {j - 1} {k}";
                            }

                            resultingCave[j - 1, k] = 'B';

                        }
                        catch (Exception) { }

                        try
                        {
                            var element = resultingCave[j + 1, k];
                            if (element.Equals('P'))
                            {
                                died = true;
                                output = $"dead: {j + 1} {k}";
                            }
                            resultingCave[j + 1, k] = 'B';
                        }
                        catch (Exception) { }

                        try
                        {
                            var element = resultingCave[j, k - 1];
                            if (element.Equals('P'))
                            {
                                died = true;
                                output = $"dead: {j } {k - 1}";
                            }
                            resultingCave[j, k - 1] = 'B';
                        }
                        catch (Exception) { }

                        try
                        {
                            var element = resultingCave[j, k + 1];
                            if (element.Equals('P'))
                            {
                                died = true;
                                output = $"dead: {j } {k + 1}";
                            }
                            resultingCave[j, k + 1] = 'B';
                        }
                        catch (Exception) { }

                        resultingCave[j, k] = 'B';
                    }
                }

                Array.Copy(resultingCave, matr, resultingCave.Length);
                if (!died && !escaped)
                    continue;

                for (var l = 0; l < row; l++)
                {
                    for (var m = 0; m < col; m++)
                        Console.Write(resultingCave[l, m]);

                    Console.WriteLine();
                }

                Console.WriteLine(output);
                return;
            }
        }
    }
}
