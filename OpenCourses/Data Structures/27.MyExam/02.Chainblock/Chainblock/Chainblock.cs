using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{
    Dictionary<int, Transaction> transactions;

    public Chainblock()
    {
        this.transactions = new Dictionary<int, Transaction>();
    }

    public int Count => this.transactions.Count;

    public void Add(Transaction tx)
    {
        if (!this.transactions.ContainsKey(tx.Id))
        {
            this.transactions.Add(tx.Id, tx);
        }
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!this.transactions.ContainsKey(id))
        {
            throw new ArgumentException();
        }
        var seekTrans = this.transactions[id];
        seekTrans.Status = newStatus;

    }

    public bool Contains(Transaction tx)
    {
        return this.transactions.ContainsKey(tx.Id);
    }

    public bool Contains(int id)
    {
        return this.transactions.ContainsKey(id);
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        return this.transactions.Values.Where(x => x.Amount >= lo && x.Amount <= hi).ToList();
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return this.transactions.OrderByDescending(x => x.Value.Amount).ThenBy(x => x.Key).Select(x => x.Value).ToList();
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        var temp = this.transactions.Where(x => x.Value.Status == status).OrderByDescending(x => x.Value.Amount).Select(x => x.Value.To).ToList();
        if (temp.Count < 1)
        {
            throw new InvalidOperationException();
        }
        return temp;
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        var temp = this.transactions.Where(x => x.Value.Status == status).OrderByDescending(x => x.Value.Amount).Select(x => x.Value.From).ToList();
        if(temp.Count < 1)
        {
            throw new InvalidOperationException();
        }
        return temp;
    }

    public Transaction GetById(int id)
    {
        if (!this.transactions.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        return this.transactions[id];
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        var temp = this.transactions.Where(x => x.Value.Amount >= lo && x.Value.Amount < hi && x.Value.To == receiver).OrderByDescending(x => x.Value.Amount).ThenBy(x => x.Value.Id).Select(x => x.Value).ToList();

        if(temp.Count < 1)
        {
            throw new InvalidOperationException();
        }

        return temp;
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        var temp = this.transactions.Where(x => x.Value.To == receiver).OrderByDescending(x => x.Value.Amount).ThenBy(x => x.Key).Select(x => x.Value).ToList();

        if (temp.Count < 1)
        {
            throw new InvalidOperationException();
        }

        return temp;
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        var temp = this.transactions.Where(x => x.Value.From == sender && x.Value.Amount > amount).OrderByDescending(x => x.Value.Amount).Select(x => x.Value).ToList();

        if (temp.Count < 1)
        {
            throw new InvalidOperationException();
        }

        return temp;
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        var temp = this.transactions.Where(x => x.Value.From == sender).OrderByDescending(x => x.Value.Amount).Select(x => x.Value).ToList();

        if (temp.Count < 1)
        {
            throw new InvalidOperationException();
        }

        return temp;
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        var temp = this.transactions.Where(x => x.Value.Status == status).OrderByDescending(x => x.Value.Amount).Select(x => x.Value).ToList();
        if (temp.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return temp; 
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        var temp = this.transactions.Where(x => x.Value.Status == status && x.Value.Amount <= amount).OrderByDescending(x => x.Value.Amount).Select(x => x.Value).ToList();

        return temp;
    }    

    public void RemoveTransactionById(int id)
    {
        if (!this.transactions.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        this.transactions.Remove(id);
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var trans in this.transactions)
        {
            yield return trans.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

