using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P04_ShoppingSpree
{
    class P04_ShoppingSpree
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();

            try
            {
                string people = Console.ReadLine();
                string[] peopleMatched = people.Split(';');
                foreach (string currMan in peopleMatched)
                {
                    string[] currPair = currMan.Split('=');
                    string currName = currPair[0];
                    decimal money = decimal.Parse(currPair[1]);
                    Person addPerson = new Person(currName, money);
                    personList.Add(addPerson);
                }

                string productsInput = Console.ReadLine();
                string[] productsMatched = productsInput.Split(';');
                foreach (string currProd in productsMatched)
                {
                    string[] currPair = currProd.Split('=');
                    string currName = currPair[0];
                    decimal cost = decimal.Parse(currPair[1]);
                    Product addProduct = new Product(currName, cost);
                    productList.Add(addProduct);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commTokens = command.Split();

                    string currCustomerName = commTokens[0];
                    string currProductName = commTokens[1];

                    var currCustomer = personList.FirstOrDefault(x => x.Name == currCustomerName);

                    var currProduct = productList.FirstOrDefault(x => x.Name == currProductName);

                    if(currCustomer.Money < currProduct.Cost)
                    {
                        Console.WriteLine($"{currCustomerName} can't afford {currProductName}");
                    }
                    else
                    {
                        currCustomer.Money -= currProduct.Cost;
                        currCustomer.Bag.Add(currProduct);
                        Console.WriteLine($"{currCustomerName} bought {currProductName}");
                    }
                }

                foreach (var man in personList)
                {
                    if(man.Bag.Count > 0)
                    {
                        Console.WriteLine($"{man.Name} - {string.Join(", ", man.Bag)}");
                    }
                    else
                    {
                        Console.WriteLine($"{man.Name} - Nothing bought");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
