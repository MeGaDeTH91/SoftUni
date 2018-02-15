using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PizzaIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingrArr = Console.ReadLine().Split(' ').ToArray();
            int checkLenght = int.Parse(Console.ReadLine());

            int ingrNum = 0;
            string allIngr = string.Empty;
            for (int i = 0; i < ingrArr.Length; i++)
            {
                string currentIngr = ingrArr[i];

                if(currentIngr.Length == checkLenght)
                {
                    if(ingrNum == 10)
                    {
                        break;
                    }
                    ingrNum++;
                    Console.WriteLine("Adding {0}.", currentIngr);
                    allIngr +=  currentIngr + ", ";
                }
            }
            Console.WriteLine("Made pizza with total of {0} ingredients.", ingrNum);
            allIngr = allIngr.Remove(allIngr.Length - 2);
            allIngr = allIngr + ".";
            Console.WriteLine("The ingredients are: {0}", allIngr);
        }
    }
}
