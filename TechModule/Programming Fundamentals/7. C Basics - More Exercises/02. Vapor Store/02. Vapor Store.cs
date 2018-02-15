using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Vapor_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            var balance = double.Parse(Console.ReadLine());

            var startbalance = balance;
            var resetbalance = 0.0;
            var outfallprice = 39.99;
            var csogprice = 15.99;
            var zplintercellprice = 19.99;
            var honoredprice = 59.99;
            var roverwprice = 29.99;
            var roverworiginprice = 39.99;
            var totalspent = 0.0;

            for (int i = 1; i < 1000; i++)
            {
                var game = Console.ReadLine();
                if (game == "OutFall 4")
                {
                    resetbalance = balance;
                    balance = balance - outfallprice;
                    if (balance < 0)
                    {
                        balance = resetbalance;
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        totalspent = totalspent + outfallprice;
                        Console.WriteLine("Bought {0}", game);
                    }
                    
                }
                else if (game == "CS: OG")
                {
                    resetbalance = balance;
                    balance = balance - csogprice;
                    if (balance < 0)
                    {
                        balance = resetbalance;
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        totalspent = totalspent + csogprice;
                        Console.WriteLine("Bought {0}", game);
                    }

                }
                else if (game == "Zplinter Zell")
                {
                    resetbalance = balance;
                    balance = balance - zplintercellprice;
                    if (balance < 0)
                    {
                        balance = resetbalance;
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        totalspent = totalspent + zplintercellprice;
                        Console.WriteLine("Bought {0}", game);
                    }

                }
                else if (game == "Honored 2")
                {
                    resetbalance = balance;
                    balance = balance - honoredprice;
                    if (balance < 0)
                    {
                        balance = resetbalance;
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        totalspent = totalspent + honoredprice;
                        Console.WriteLine("Bought {0}", game);
                    }

                }
                else if (game == "RoverWatch")
                {
                    resetbalance = balance;
                    balance = balance - roverwprice;
                    if (balance < 0)
                    {
                        balance = resetbalance;
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        totalspent = totalspent + roverwprice;
                        Console.WriteLine("Bought {0}", game);
                    }

                }
                else if (game == "RoverWatch Origins Edition")
                {
                    resetbalance = balance;
                    balance = balance - roverworiginprice;
                    if (balance < 0)
                    {
                        balance = resetbalance;
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        totalspent = totalspent + roverworiginprice;
                        Console.WriteLine("Bought {0}", game);
                    }

                }
                else if (game == "Game Time")
                {
                    var remaining = startbalance - totalspent;
                    if (balance == 0)
                    {
                        Console.WriteLine("Out of money!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Total spent: ${0:F2}. Remaining: ${1:F2}", totalspent, remaining);
                        return;
                    }
                    
                }
                //if (balance == 0)
                //{
                //    Console.WriteLine("Out of money!");
                //}
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
        }
    }
}
