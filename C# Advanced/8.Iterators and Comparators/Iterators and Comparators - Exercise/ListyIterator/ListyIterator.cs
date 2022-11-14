using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> colection;
        private int currIndex;

        public ListyIterator(params T[] data)
        {
            colection = new List<T>(data);
            currIndex = 0;
        }

        public bool HasNext() => currIndex < colection.Count - 1;

        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                currIndex++;
            }
            return canMove;
        }

        public void Print()
        {
            if (colection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation");
            }

            Console.WriteLine($"{colection[currIndex]}");
        }

        public void PrintAll() => Console.WriteLine(string.Join(" ", colection));

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in colection)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
