namespace P01_Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private const int Initial_Capacity = 16;

        private int[] arr;

        public IReadOnlyCollection<int> DatabaseNumbers { get { return this.arr.Take(this.Count).ToList().AsReadOnly(); } }

        public int Count { get; private set; }

        public Database(params int[] numbers)
        {
            this.arr = new int[Initial_Capacity];
            InitializeArray(numbers);
        }

        public void Add(int number)
        {
            if(this.Count + 1 > Initial_Capacity)
            {
                throw new InvalidOperationException("Database capacity exceeded!");
            }
            this.arr[this.Count] = number;
            this.Count++;
        }

        public void Remove()
        {
            if (this.Count.Equals(0))
            {
                throw new InvalidOperationException("No elements in Database!");
            }
            this.Count--;
            this.arr[this.Count] = default(int);
        }

        public int[] Fetch()
        {
            return this.arr.Take(this.Count).ToArray();
        }

        private void InitializeArray(int[] numbers)
        {
            foreach (var element in numbers)
            {
                this.Add(element);
            }
        }
    }
}
