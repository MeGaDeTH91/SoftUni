using LimitedMemory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LimitedMemoryCollection<K, V> : ILimitedMemoryCollection<K, V>
{
    Dictionary<K, V> elements;
    List<Pair<K, V>> listElements;

    public int Capacity { get; set; }

    public LimitedMemoryCollection(int capacity)
    {
        this.Capacity = capacity;
        this.elements = new Dictionary<K, V>(capacity);
        this.listElements = new List<Pair<K, V>>(capacity);
    }

    public int Count => this.elements.Count;

    public V Get(K key)
    {
        if (!this.elements.ContainsKey(key))
        {
            throw new ArgumentException();
        }
        var dicElement = this.elements[key];

        var seekElementIndex = listElements.IndexOf(new Pair<K, V>(key, dicElement));
        var seekElement = listElements[seekElementIndex];
        listElements.RemoveAt(seekElementIndex);
        listElements.Insert(0, seekElement);
        return this.elements[key];
    }

    public void Set(K key, V value)
    {
        if (this.elements.ContainsKey(key))
        {
            var dicElement = this.elements[key];
            dicElement = value;

            var seekElementIndex = listElements.IndexOf(new Pair<K, V>(key, dicElement));
            listElements.RemoveAt(seekElementIndex);
            listElements.Insert(0, new Pair<K, V>(key, value));
        }
        else
        {
            if (this.elements.Count == this.Capacity)
            {
                var element = this.listElements[this.Capacity - 1];
                this.elements.Remove(element.Key);
                this.listElements.RemoveAt(this.Capacity - 1);
                var newElement = new Pair<K, V>(key, value);
                this.listElements.Insert(0, newElement);
                this.elements.Add(key, value);
            }
            else
            {
                var newElement = new Pair<K, V>(key, value);
                this.listElements.Insert(0, newElement);
                this.elements.Add(key, value);
            }
        }
    }

    public IEnumerator<Pair<K, V>> GetEnumerator()
    {
        for (int index = 0; index < this.listElements.Count; index++)
        {
            yield return this.listElements[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
