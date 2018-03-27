using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        string[] nameAndAdress = Console.ReadLine().Split();
        string fullName = $"{nameAndAdress[0]} {nameAndAdress[1]}";
        string adress = nameAndAdress[2];

        Tuple<string, string> tuple1 = new Tuple<string, string>(fullName, adress);

        string[] nameAndBeer = Console.ReadLine().Split();

        string nameOfDrinker = nameAndBeer.First();
        int beerAmount = int.Parse(nameAndBeer.Last());

        Tuple<string, int> tuple2 = new Tuple<string, int>(nameOfDrinker, beerAmount);

        string[] intDouble = Console.ReadLine().Split();

        int integer = int.Parse(intDouble.First());
        double doubleNum = double.Parse(intDouble.Last());
        

        Tuple<int, double> tuple3 = new Tuple<int, double>(integer, doubleNum);

        Console.WriteLine(tuple1);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);
    }
}
