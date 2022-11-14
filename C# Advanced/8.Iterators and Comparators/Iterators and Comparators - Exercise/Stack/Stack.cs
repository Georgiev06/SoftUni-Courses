using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {

        private List<T> colection;

        public Stack(params T[] data)
        {
            colection = new List<T>(data);
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                colection.Insert(colection.Count, element);
            }
        }

        public T Pop()
        {
            if (colection.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            T element = colection[colection.Count - 1];
            colection.RemoveAt(colection.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = colection.Count - 1; i >= 0; i--)
            {
                yield return colection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
