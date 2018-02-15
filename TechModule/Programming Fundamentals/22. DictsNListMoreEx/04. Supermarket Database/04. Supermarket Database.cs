using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Supermarket_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(' ')
                .ToList();
            var productQuant = new Dictionary<string, double>();
            var productPrice = new Dictionary<string, double>();
            string productName = input[0];
            double quantity = double.Parse(input[2]);
            double price = double.Parse(input[1]);
            double productCost = 0.0d;
            double grandTotal = 0.0d;
            while (input[0] != "stocked")
            {
                productName = input[0];
                quantity = double.Parse(input[2]);
                price = double.Parse(input[1]);
                if(productQuant.ContainsKey(productName) &&
                    productPrice.ContainsKey(productName))
                {
                    if(productPrice[productName] != price)
                    {
                        productPrice[productName] = price;
                        productQuant[productName] += quantity;
                    }
                    else
                    {
                        productQuant[productName] += quantity;
                    }
                }
                else
                {
                    productQuant.Add(productName, quantity);
                    productPrice.Add(productName, price);
                }
                
                input = Console.ReadLine()
                .Split(' ')
                .ToList();
            }
            foreach (var currName in productQuant)
            {
                foreach (var currPrice in productPrice)
                {
                    if(currName.Key == currPrice.Key)
                    {
                        productCost = currName.Value * currPrice.Value;
                        grandTotal += productCost;

                        Console.WriteLine($"{currName.Key:F2}: ${currPrice.Value:F2} * {currName.Value} = ${productCost:F2}");
                        productCost = 0;
                    }
                    
                }
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${grandTotal:F2}");

        }
    }
}
