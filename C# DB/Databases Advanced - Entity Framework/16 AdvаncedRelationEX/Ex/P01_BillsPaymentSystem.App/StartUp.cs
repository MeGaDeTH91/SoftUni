namespace P01_BillsPaymentSystem.App
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            //Задача 2 - Seed метод
            //using (var context = new BillsPaymentSystemContext())
            //{
            //    ResetDatabase(context);
            //    Console.WriteLine("Database was reseted and seeded successfully!");
            //}

            //Задача 3 - User Details
            //using (var context = new BillsPaymentSystemContext())
            //{
            //    int userId = int.Parse(Console.ReadLine());
            //    UserDetailsById(userId, context);
            //}

            //Задача 4.1 - Withdraw
            //using (var context = new BillsPaymentSystemContext())
            //{
            //    Console.Write($"Enter user Id: ");
            //    int userId = int.Parse(Console.ReadLine());

            //    Console.Write("Enter amount of money: ");
            //    decimal amount = decimal.Parse(Console.ReadLine());
            //    try
            //    {
            //        PayBills(userId, amount, context);
            //        Console.WriteLine("Bills were successfully paid!");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}

            //Задача 4.2 - Deposit
            //using (var context = new BillsPaymentSystemContext())
            //{
            //    Console.Write($"Enter user Id: ");
            //    int userId = int.Parse(Console.ReadLine());

            //    Console.Write("Enter amount of money to deposit: ");
            //    decimal amount = decimal.Parse(Console.ReadLine());
            //    try
            //    {
            //        DepositMoney(userId, amount, context);
            //        Console.WriteLine("Money were successfully deposited!");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}
        }

        private static void DepositMoney(int userId, decimal amount, BillsPaymentSystemContext context)
        {
            decimal startAmount = amount;

            if (!context.Users.Any(x => x.UserId == userId))
            {
                throw new ArgumentException($"User with id {userId} not found!");
            }

            var user = context.Users
                .Where(x => x.UserId == userId)
                .Select(x => new
                {
                    Name = $"{x.FirstName} {x.LastName}",
                    BankAccounts = x.PaymentMethods
                    .OrderBy(i => i.BankAccountId)
                    .Where(ba => ba.Type == PaymentMethodType.BankAccount)
                    .Select(ba => ba.BankAccount).ToList(),
                    CreditCards = x.PaymentMethods
                    .OrderBy(i => i.CreditCardId)
                    .Where(y => y.Type == PaymentMethodType.CreditCard)
                    .Select(cc => cc.CreditCard).ToList()
                }).FirstOrDefault();

            bool moneyAreDeposited = false;
            if(user.BankAccounts.Any() || user.CreditCards.Any())
            {
                foreach (var acc in user.BankAccounts)
                {
                    var currAccount = context.BankAccounts.Find(acc.BankAccountId);

                    currAccount.Deposit(amount);
                    moneyAreDeposited = true;
                    context.SaveChanges();
                    return;
                }

                foreach (var card in user.CreditCards)
                {
                    var currCard = context.CreditCards.Find(card.CreditCardId);

                    if (currCard.MoneyOwed >= amount)
                    {
                        currCard.MoneyOwed -= amount;
                        currCard.Deposit(amount);

                        moneyAreDeposited = true;
                    }
                    else if(currCard.MoneyOwed > 0)
                    {
                        amount -= currCard.MoneyOwed;
                        currCard.Deposit(currCard.MoneyOwed);
                    }
                    if (moneyAreDeposited)
                    {
                        context.SaveChanges();
                        return;
                    }
                }
                if (!moneyAreDeposited)
                {
                    context.SaveChanges();
                    Console.WriteLine($"{startAmount - amount:F2} were successfully deposited!");
                    Console.WriteLine($"Please provide valid Bank Account or Credit Card for the rest {amount:F2}");
                }
            }
            else
            {
                throw new InvalidOperationException("The user does not have any bank account or credit card!");
            }
        }

        private static void PayBills(int userId, decimal amount, BillsPaymentSystemContext context)
        {
            if (!context.Users.Any(x => x.UserId == userId))
            {
                throw new ArgumentException($"User with id {userId} not found!");
            }

            var user = context.Users
                .Where(x => x.UserId == userId)
                .Select(x => new
                {
                    Name = $"{x.FirstName} {x.LastName}",
                    BankAccounts = x.PaymentMethods
                    .OrderBy(i => i.BankAccountId)
                    .Where(ba => ba.Type == PaymentMethodType.BankAccount)
                    .Select(ba => ba.BankAccount).ToList(),
                    CreditCards = x.PaymentMethods
                    .OrderBy(i => i.CreditCardId)
                    .Where(y => y.Type == PaymentMethodType.CreditCard)
                    .Select(cc => cc.CreditCard).ToList()
                }).FirstOrDefault();

            decimal bankAccBalance = 0.0m;
            foreach (var acc in user.BankAccounts)
            {
                decimal currBal = acc.Balance;
                bankAccBalance += currBal;
            }

            decimal cardBalance = 0.0m;
            foreach (var card in user.CreditCards)
            {
                decimal currLeftLimit = card.LimitLeft;
                cardBalance += currLeftLimit;
            }

            decimal totalBalance = bankAccBalance + cardBalance;

            if(totalBalance < amount)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }

            bool billsArePaid = false;

            foreach (var acc in user.BankAccounts)
            {
                var currAccount = context.BankAccounts.Find(acc.BankAccountId);

                if(amount<= currAccount.Balance)
                {
                    currAccount.Withdraw(amount);
                    billsArePaid = true;
                }
                else
                {
                    amount -= currAccount.Balance;
                    currAccount.Withdraw(currAccount.Balance);
                }

                if (billsArePaid)
                {
                    
                    context.SaveChanges();
                    return;
                }
            }

            foreach (var card in user.CreditCards)
            {
                var currCard = context.CreditCards.Find(card.CreditCardId);

                if(amount <= currCard.LimitLeft)
                {
                    currCard.Withdraw(amount);
                    billsArePaid = true;
                }
                else
                {
                    amount -= currCard.LimitLeft;
                    currCard.Withdraw(currCard.LimitLeft);
                }

                if (billsArePaid)
                {
                    context.SaveChanges();
                    return;
                }
            }
        }

        private static void UserDetailsById(int userId, BillsPaymentSystemContext context)
        {
            if(!context.Users.Any(x => x.UserId == userId))
            {
                Console.WriteLine($"User with id {userId} not found!");
            }
            else
            {
                var user = context.Users
                    .Where(x => x.UserId == userId)
                    .Select(u => new
                    {
                        Name = $"{u.FirstName} {u.LastName}",
                        CreditCards = u.PaymentMethods
                        .Where(x => x.Type == PaymentMethodType.CreditCard)
                        .Select(x => x.CreditCard).ToList(),
                        BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                        .Select(x => x.BankAccount).ToList()
                    }).FirstOrDefault();

                Console.WriteLine($"{user.Name}");

                var bankAccounts = user.BankAccounts;
                if (bankAccounts.Any())
                {
                    Console.WriteLine("Bank Accounts:");
                    foreach (var acc in bankAccounts)
                    {
                        Console.WriteLine($"-- ID: {acc.BankAccountId}");
                        Console.WriteLine($"--- Balance: {acc.Balance:F2}");
                        Console.WriteLine($"--- Bank: {acc.BankName}");
                        Console.WriteLine($"--- SWIFT: {acc.SwiftCode}");
                    }
                }

                var creditCards = user.CreditCards;
                if (creditCards.Any())
                {
                    Console.WriteLine("Credit Cards:");
                    foreach (var card in creditCards)
                    {
                        string format = @"yyyy/MM";
                        string expDate = card.ExpirationDate.ToString(format, CultureInfo.InvariantCulture);
                        
                        Console.WriteLine($"-- ID: {card.CreditCardId}");
                        Console.WriteLine($"--- Limit: {card.Limit:F2}");
                        Console.WriteLine($"--- Money Owed: {card.MoneyOwed:F2}");
                        Console.WriteLine($"--- Limit Left: {card.LimitLeft:F2}");
                        Console.WriteLine($"--- Expiration Date: {expDate}");
                    }
                }
            }
            
        }

        private static void ResetDatabase(BillsPaymentSystemContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.Migrate();

            Seed(context);
        }

        private static void Seed(BillsPaymentSystemContext context)
        {
            List<User> users = new List<User>()
            {
                new User
                {
                    FirstName = "Tomas",
                    LastName = "Jefferson",
                    Password = "1234",
                    Email = "pich1@yahoo.com"
                },
                new User
                {
                    FirstName = "Abraham",
                LastName = "Lincoln",
                Password = "1234",
                Email = "pich2@yahoo.com"
                },
                new User
                {
                    FirstName = "Frank",
                LastName = "Sinatra",
                Password = "1234",
                Email = "pich3@yahoo.com"
                }
        };
            context.Users.AddRange(users);
            context.SaveChanges();

            List<CreditCard> creditCards = new List<CreditCard>()
            {
                new CreditCard
                {
                    ExpirationDate = DateTime.ParseExact("11.10.2020", "MM.dd.yyyy", null),
                    Limit = 1000.00m,
                    MoneyOwed = 0.0m
                },
                new CreditCard
                {
                    ExpirationDate = DateTime.ParseExact("08.21.2021", "MM.dd.yyyy", null),
                    Limit = 1500.00m,
                    MoneyOwed = 0.0m
                },
                new CreditCard
                {
                    ExpirationDate = DateTime.ParseExact("09.20.2022", "MM.dd.yyyy", null),
                    Limit = 2000.00m,
                    MoneyOwed = 0.0m
                },
                new CreditCard
                {
                    ExpirationDate = DateTime.ParseExact("03.24.2021", "MM.dd.yyyy", null),
                    Limit = 1500.00m,
                    MoneyOwed = 0.0m
                },
                new CreditCard
                {
                    ExpirationDate = DateTime.ParseExact("09.25.2021", "MM.dd.yyyy", null),
                    Limit = 1500.00m,
                    MoneyOwed = 0.0m
                }
            };
            context.CreditCards.AddRange(creditCards);
            context.SaveChanges();

            List<BankAccount> bankAccounts = new List<BankAccount>()
            {
                new BankAccount
                {
                    Balance = 1250.00m,
                    BankName = "Unicredit",
                    SwiftCode = "UNCBANK"
                },
                new BankAccount
                {
                    Balance = 1900.00m,
                    BankName = "Swiss Bank",
                    SwiftCode = "SWSSBANK"
                },
                new BankAccount
                {
                    Balance = 1500.00m,
                    BankName = "First Investment Bank",
                    SwiftCode = "FRSTINVSTMNBANK"
                }
            };
            context.BankAccounts.AddRange(bankAccounts);
            context.SaveChanges();

            List<PaymentMethod> paymentMethods = new List<PaymentMethod>()
            {
                new PaymentMethod
                {
                    User = users[0],
                    CreditCard = creditCards[0],
                    Type = PaymentMethodType.CreditCard,
                },
                new PaymentMethod
                {
                    User = users[0],
                    CreditCard = creditCards[3],
                    Type = PaymentMethodType.CreditCard,
                },
                new PaymentMethod
                {
                    User = users[1],
                    CreditCard = creditCards[1],
                    Type = PaymentMethodType.CreditCard,
                },
                new PaymentMethod
                {
                    User = users[2],
                    CreditCard = creditCards[2],
                    Type = PaymentMethodType.CreditCard,
                },
                new PaymentMethod
                {
                    User = users[0],
                    BankAccount = bankAccounts[0],
                    Type = PaymentMethodType.BankAccount,
                },
                new PaymentMethod
                {
                    User = users[1],
                    BankAccount = bankAccounts[1],
                    Type = PaymentMethodType.BankAccount,
                }
            };
            context.PaymentMethods.AddRange(paymentMethods);
            context.SaveChanges();
        }
    }
}
