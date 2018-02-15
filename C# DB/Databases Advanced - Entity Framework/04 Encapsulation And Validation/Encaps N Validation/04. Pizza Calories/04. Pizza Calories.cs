using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] pizzaInput = Console.ReadLine()
                .Split().ToArray();
            string pizzaName = pizzaInput[1];

            string[] doughInput = Console.ReadLine()
                .Split().ToArray();
            string doughFlour = doughInput[1];
            string doughBakinType = doughInput[2];
            decimal doughWeight = decimal.Parse(doughInput[3]);
            Dough currDough = new Dough(doughFlour, doughBakinType, doughWeight);
            Pizza currPizza = new Pizza(pizzaName, new List<Topping>());
            string toppingInput;
            List<Topping> currToppings = new List<Topping>();
            while ((toppingInput = Console.ReadLine()) != "END")
            {
                string[] commandInp = toppingInput
                    .Split().ToArray();
                string toppName = commandInp[1];
                decimal toppWeight = decimal.Parse(commandInp[2]);
                Topping currTopp = new Topping(toppName, toppWeight);
                currPizza.AddTopping(currTopp);
            }

            
            currPizza.Dough = currDough;
            Console.WriteLine(currPizza);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
    }
}