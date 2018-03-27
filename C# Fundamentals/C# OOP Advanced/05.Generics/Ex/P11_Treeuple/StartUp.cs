using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        string[] nameAndAdress = Console.ReadLine().Split();
        string fullName = $"{nameAndAdress[0]} {nameAndAdress[1]}";
        string adress = nameAndAdress[2];
        string town = nameAndAdress[3];

        Treeuple<string, string, string> tuple1 = new Treeuple<string, string, string>(fullName, adress, town);

        string[] nameAndBeer = Console.ReadLine().Split();

        string nameOfDrinker = nameAndBeer.First();
        int beerAmount = int.Parse(nameAndBeer[1]);
        string drunk = nameAndBeer.Last() == "drunk"? "True":"False";


        Treeuple<string, int, string> tuple2 = new Treeuple<string, int, string>(nameOfDrinker, beerAmount, drunk);

        string[] bankDetails = Console.ReadLine().Split();

        string accountName = bankDetails.First();
        double accountBalance = double.Parse(bankDetails[1]);
        string bankName = bankDetails.Last();

        Treeuple<string, double, string> tuple3 = new Treeuple<string, double, string>(accountName, accountBalance, bankName);

        Console.WriteLine(tuple1);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);
    }
}
