using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Threeuple<TfirstElement, TsecondElement, TthirdElement>
    {
        public Threeuple(TfirstElement firstElement, TsecondElement secondElement, TthirdElement thirdElement)
        {
            this.FirstElement = firstElement;
            this.SecondElement = secondElement;
            this.ThirdElement = thirdElement;
        }

        public TfirstElement FirstElement { get; set; }
        public TsecondElement SecondElement { get; set; }
        public TthirdElement ThirdElement { get; set; }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement} -> {ThirdElement}"; 
        }
    }
}
