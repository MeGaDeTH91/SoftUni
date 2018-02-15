using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusTicketSystem.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }

            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Value cannot be zero or negative");
            }

            this.Balance += amount;
        }
    }
}
