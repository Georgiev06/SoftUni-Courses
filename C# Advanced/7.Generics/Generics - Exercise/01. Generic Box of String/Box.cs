using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Box
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        public Box(T element)
        {
            this.Element = element;
        }
        public Box(List<T> elements)
        {
            this.Elements = elements;
        }

        public List<T> Elements { get; }
        public T Element { get; }

        public void Swap(List<T> elements, int firstIndex, int secondIndex)
        {
            T firstEl = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstEl;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (T element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }

        public int CompareTo(T other) => Element.CompareTo(other);

        public int CountOFGreaterElements<T>(List<T> list, T readLine) where T : IComparable
        => list.Count(word => word.CompareTo(readLine) > 0);

    }
}
