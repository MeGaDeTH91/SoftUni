using System;
using System.Collections.Generic;

namespace P05_PizzaCal
{
    class P05_PizzaCal
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split();
                string pizzaName = pizzaInput[1];
                Pizza currPizza = new Pizza(pizzaName);

                string[] doughInput = Console.ReadLine().Split();
                string doughType = doughInput[1];
                string doughBake = doughInput[2];
                double doughWeight = double.Parse(doughInput[3]);

                Dough currDough = new Dough(doughType, doughBake, doughWeight);

                List<Topping> toppingList = new List<Topping>();

                string topping;
                while ((topping = Console.ReadLine()) != "END")
                {
                    string[] toppTokens = topping.Split();
                    string toppingType = toppTokens[1];
                    double toppWeight = double.Parse(toppTokens[2]);

                    Topping currTopp = new Topping(toppingType, toppWeight);
                    toppingList.Add(currTopp);
                }

                currPizza = new Pizza(pizzaName, currDough, toppingList);
                double totalCalories = currPizza.TotalCalories;

                Console.WriteLine($"{pizzaName} - {totalCalories:F2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
