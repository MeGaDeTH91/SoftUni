using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        try
        {
            people = Console.ReadLine().Split(';').ToList()
                .Select(x => x.Split('='))
                .Select(p => new Person(p[0], decimal.Parse(p[1])))
                .ToList();

            products = Console.ReadLine().Split(new[] { ';' },StringSplitOptions.RemoveEmptyEntries).ToList()
                .Select(x => x.Split('='))
                .Select(p => new Product(p[0], decimal.Parse(p[1])))
                .ToList();
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
            return;
        }

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] args = command.Split().ToArray();
            Person currPerson = people.First(x => x.Name == args[0]);
            Product currProduct = products.First(x => x.Name == args[1]);

            Console.WriteLine(currPerson.AddToBag(currProduct));
        }

        people.ForEach(p => Console.WriteLine(p));
    }
}