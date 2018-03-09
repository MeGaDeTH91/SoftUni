using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EntryPoint
{
    public static void Main()
    {
        var sc = new ShoppingCenter();

        var commands = int.Parse(Console.ReadLine());

        for(int i = 0; i < commands; i++)
        {
            string line = Console.ReadLine();

            int firstSpace = line.IndexOf(" ");

            string command = line.Substring(0, firstSpace);
            string[] tokens = line.Substring(firstSpace + 1).Split(';');

            switch (command)
            {
                case "AddProduct":
                    {
                        string addName = tokens[0];
                        double addPrice = double.Parse(tokens[1]);
                        string addProducer = tokens[2];
                        sc.AddProduct(addName,addPrice, addProducer);
                        Console.WriteLine("Product added");
                        break;
                    }
                case "DeleteProducts":
                    {
                        int count = 0;
                        if(tokens.Length == 1)
                        {
                            string currProducer = tokens[0];
                            count = sc.DeleteProductsByProducer(currProducer);
                        }
                        else
                        {
                            string deleteName = tokens[0];
                            string deleteProducer = tokens[1];
                            count = sc.DeleteProductsByProducerAndName(deleteName, deleteProducer);
                        }
                        PrintRemoveMessage(count);
                        break;
                    }
                case "FindProductsByName":
                    {
                        string findByName = tokens[0];
                        PrintProducts(sc.FindProductsByName(findByName).ToList());
                        break;
                    }
                case "FindProductsByProducer":
                    {
                        string findByProd = tokens[0];
                        PrintProducts(sc.FindProductsByProducer(findByProd).ToList());
                        break;
                    }
                case "FindProductsByPriceRange":
                    {
                        double lowerRange = double.Parse(tokens[0]);
                        double upperRange = double.Parse(tokens[1]);

                        PrintProducts(sc.FindProductsByPriceRange(lowerRange, upperRange).OrderBy(x => x).ToList());
                        break;
                    }
            }
        }
    }

    private static void PrintRemoveMessage(int count)
    {
        if (count > 0)
        {
            Console.WriteLine($"{count} products deleted");
        }
        else
        {
            Console.WriteLine("No products found");
        }
    }

    public static void PrintProducts(List<Product> products)
    {
        var sb = new StringBuilder();

        if (products.Count == 0)
        {
            sb.AppendLine("No products found");
        }
        else
        {
            foreach (var product in products)
            {
                sb.AppendLine(product.ToString());
            }
        }

        Console.Write(sb.ToString());
    }
}

