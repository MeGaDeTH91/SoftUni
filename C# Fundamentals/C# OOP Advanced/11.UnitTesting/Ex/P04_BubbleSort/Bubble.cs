namespace P04_BubbleSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bubble<T> where T : IComparable<T>
    {
        private List<T> elements;

        public IReadOnlyCollection<T> BubbleSortedList { get { return this.elements.AsReadOnly(); } }

        public Bubble(params T[] elements)
        {
            this.elements = elements.ToList();
        }

        public void Sort()
        {
            int endIndex = this.elements.Count - 1;

            while (true)
            {
                for (int outerIndex = 0; outerIndex < endIndex; outerIndex++)
                {
                    T currentElement = this.elements[outerIndex];
                    T nextElement = this.elements[outerIndex + 1];

                    if (IsElementLarger(currentElement, nextElement))
                    {
                        Swap(outerIndex, outerIndex + 1);
                    }
                    
                }
                endIndex--;
                if (endIndex == 0)
                {
                    break;
                }
            }
        }

        private void Swap(int currentIndex, int nextIndex)
        {
            T temp = this.elements[currentIndex];
            this.elements[currentIndex] = this.elements[nextIndex];
            this.elements[nextIndex] = temp;
        }

        private bool IsElementLarger(T currentElement, T nextElement)
        {
            return currentElement.CompareTo(nextElement) > 0;
        }
    }
}
