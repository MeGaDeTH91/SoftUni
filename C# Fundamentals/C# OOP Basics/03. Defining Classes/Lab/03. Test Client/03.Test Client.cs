using System;
using System.Collections.Generic;
using System.Linq;

public class TestClient
{
    public static void Main(string[] args)
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] cmdArgs = input.Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries).ToArray();

            string currCommand = cmdArgs[0];

            switch (currCommand)
            {
                case "Create":
                    Create(cmdArgs, accounts);
                    break;
                case "Deposit":
                    Deposit(cmdArgs, accounts);
                    break;
                case "Withdraw":
                    Withdraw(cmdArgs, accounts);
                    break;
                case "Print":
                    Print(cmdArgs, accounts);
                    break;
                default:
                    break;
            }
        }
    }

    public static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(cmdArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(accounts[id]);
        }
    }

    public static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(cmdArgs[1]);
        decimal currWithAmount = decimal.Parse(cmdArgs[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        if (currWithAmount > accounts[id].Balance)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            accounts[id].Balance -= currWithAmount;
        }
    }

    public static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(cmdArgs[1]);
        decimal currDepAmount = decimal.Parse(cmdArgs[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            accounts[id].Balance += currDepAmount;
        }
    }

    public static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(cmdArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account already exists");
        }
        else
        {
            BankAccount acc = new BankAccount
            {
                Id = id,
                Balance = 0
            };
            accounts[id] = acc;
        }
    }
}
