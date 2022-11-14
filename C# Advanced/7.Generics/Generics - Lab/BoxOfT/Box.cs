using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;

        public int Count
        {
            get { return data.Count; }
        }
        public Box()
        {
            this.data = new List<T>();
        }
        public void Add(T item)
        {
            this.data.Add(item);
        }
        public T Remove()
        {
            var lastItem = this.data.Last();
            this.data.RemoveAt(data.Count - 1);
            return lastItem;
        }
    }
}
