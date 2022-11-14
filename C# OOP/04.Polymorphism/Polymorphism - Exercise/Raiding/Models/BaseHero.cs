using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero
    {
        public BaseHero(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public  string Name { get; set; }
        public string Type { get; set; }

        public abstract int Power { get; }

        public abstract string CastAbility();

    }
}
