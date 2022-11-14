using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Tuple<Titem1, Titem2>
    {
        public Tuple(Titem1 item1, Titem2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public Titem1 Item1 { get; set; }
        public Titem2 Item2 { get; set; }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}"; 
        }
    }
}
