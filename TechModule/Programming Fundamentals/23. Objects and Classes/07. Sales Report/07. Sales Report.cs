using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sales_Report
{
    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var saleReg = new SortedDictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                Sale sale = ReadSale();
                var currentSale = sale.Price * sale.Quantity;
                if(saleReg.ContainsKey(sale.Town))
                {
                    saleReg[sale.Town] += currentSale;
                }
                else
                {
                    saleReg.Add(sale.Town, currentSale);
                }
            }
            
            foreach (var item in saleReg)
            {
                Console.WriteLine($"{item.Key:F2} -> {item.Value:F2}");
            }
        }

        private static Sale ReadSale()
        {
            string[] items = Console.ReadLine().Split(' ');
            var sale = new Sale();
            return new Sale
            {
                Town = items[0],
                Product = items[1],
                Price = decimal.Parse(items[2]),
                Quantity = decimal.Parse(items[3])
            };
        }
    }
}
