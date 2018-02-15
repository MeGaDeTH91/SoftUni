using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Andrey_and_Billiard
{
    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> BoughtProduct { get; set; }
        public decimal BillProp { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> shop = new Dictionary<string, decimal>();
            int entityNum = int.Parse(Console.ReadLine());
            SortedDictionary<string, Customer> customers = new SortedDictionary<string, Customer>();
            decimal totalBill = 0.0m;
            for (int entities = 0; entities < entityNum; entities++)
            {
                string[] input = Console.ReadLine()
                    .Split('-')
                    .ToArray();
                string currProduct = input[0];
                decimal prodPrice = decimal.Parse(input[1]);

                if (shop.ContainsKey(currProduct))
                {
                    shop[currProduct] = prodPrice;
                }
                else
                {
                    shop.Add(currProduct, prodPrice);
                }
            }
            string[] clientInput = Console.ReadLine()
                .Split('-', ',')
                .ToArray();
            while (clientInput[0] != "end of clients")
            {
                string currClient = clientInput[0];
                string currProduct = clientInput[1];
                int currQuantity = int.Parse(clientInput[2]);
                Customer currCustomer = new Customer()
                {
                    BoughtProduct = new Dictionary<string, int>()
                };
                if (shop.ContainsKey(currProduct))
                {
                    if(customers.ContainsKey(currClient))
                    {
                        customers[currClient].BillProp += currQuantity * shop[currProduct];
                        if (customers[currClient].BoughtProduct.ContainsKey(currProduct))
                        {
                            customers[currClient].BoughtProduct[currProduct] += currQuantity;
                        } 
                        else
                        {
                            customers[currClient].BoughtProduct.Add(currProduct, currQuantity);
                        }
                    }
                    else
                    {
                        customers.Add(currClient, new Customer());
                        customers[currClient].BoughtProduct = new Dictionary<string, int>();
                        customers[currClient].BoughtProduct.Add(currProduct, currQuantity);
                        customers[currClient].BillProp = currQuantity * shop[currProduct];
                    }
                }

                clientInput = Console.ReadLine()
                .Split('-', ',')
                .ToArray();
            }
            foreach (var item in customers)
            {
                totalBill += item.Value.BillProp;
            }
            foreach (var item in customers.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var innerDict in item.Value.BoughtProduct)
                {
                    Console.WriteLine($"-- {innerDict.Key} - {innerDict.Value}");
                }
                Console.WriteLine($"Bill: {item.Value.BillProp:F2}");
            }
            Console.WriteLine($"Total bill: {totalBill:F2}");
        }
    }
}
