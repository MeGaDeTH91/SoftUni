namespace P03_Iterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator
    {
        List<string> elements;

        private string currentPrint;

        private int Count => this.elements.Count;

        private int Index;

        public ListIterator(params string[] elements)
        {
            InitializeList(elements);
        }

        public ListIterator()
        {
            this.elements = new List<string>();
        }

        public bool Move()
        {
            if(this.Index + 1 < this.elements.Count)
            {
                this.Index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if(this.Index == this.elements.Count - 1)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            if(this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.elements[this.Index]);

            this.currentPrint = this.elements[this.Index];
        }

        private void InitializeList(string[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(string.Empty, "No elements provided!");
            }

            this.elements = elements.ToList();
        }
    }
}
