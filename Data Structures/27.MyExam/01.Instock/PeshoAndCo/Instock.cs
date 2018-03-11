using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Instock : IProductStock
{
    Dictionary<string, Product> products;
    List<Product> productList;
    SortedDictionary<string, Product> alphabeticalProducts;
    Dictionary<int, HashSet<Product>> orderedByQuantity;

    public Instock()
    {
        this.products = new Dictionary<string, Product>();
        this.productList = new List<Product>();
        this.alphabeticalProducts = new SortedDictionary<string, Product>();
        this.orderedByQuantity = new Dictionary<int, HashSet<Product>>();
    }

    public int Count => this.products.Count;

    public void Add(Product product)
    {
        if (!this.products.ContainsKey(product.Label))
        {
            this.products.Add(product.Label, product);
            this.productList.Add(product);
            this.alphabeticalProducts.Add(product.Label, product);
            if (!this.orderedByQuantity.ContainsKey(product.Quantity))
            {
                this.orderedByQuantity[product.Quantity] = new HashSet<Product>();
            }
            this.orderedByQuantity[product.Quantity].Add(product);
        }
    }

    public void ChangeQuantity(string product, int quantity)
    {
        if (!this.products.ContainsKey(product))
        {
            throw new ArgumentException();
        }
        var seekProduct = this.products[product];
        
        if (!this.orderedByQuantity.ContainsKey(quantity))
        {
            this.orderedByQuantity[quantity] = new HashSet<Product>();
        }
        if (this.orderedByQuantity.ContainsKey(quantity))
        {
            this.orderedByQuantity[seekProduct.Quantity].Remove(seekProduct);
        }
        seekProduct.Quantity = quantity;
        this.orderedByQuantity[quantity].Add(seekProduct);
    }

    public bool Contains(Product product)
    {
        return this.products.ContainsKey(product.Label);
    }

    public Product Find(int index)
    {
        if (index >= this.productList.Count || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        return this.productList[index];
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        List<Product> temp = this.products.Values.Where(x => x.Price == price).ToList();

        return temp;
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        var temp = new List<Product>();
        if (this.orderedByQuantity.ContainsKey(quantity))
        {
            temp = this.orderedByQuantity[quantity].ToList();
        }
        
        return temp;
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        var temp = this.products.OrderByDescending(x => x.Value.Price).Where(x => x.Value.Price > lo && x.Value.Price <= hi).Select(x => x.Value).ToList();

        return temp;
    }

    public Product FindByLabel(string label)
    {
        if (!this.products.ContainsKey(label))
        {
            throw new ArgumentException();
        }
        return this.products[label];
    }

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        var temp = new List<Product>();
        if(this.products.Count >= count)
        {
            temp = this.alphabeticalProducts.Take(count).Select(x => x.Value).ToList();
        }
        else if(this.products.Count < count || count < 0)
        {
            throw new ArgumentException();
        }
        return temp;
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        if(this.products.Count < count || count < 0)
        {
            throw new ArgumentException();
        }
        return this.products.OrderByDescending(x => x.Value.Price).Take(count).Select(x => x.Value).ToList();
    }

    public IEnumerator<Product> GetEnumerator()
    {
        foreach (var product in this.products)
        {
            yield return product.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
