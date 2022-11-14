using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int DefaultPower = 100;

        public Warrior(string name, string type) : base(name, type)
        {
        }
        public override int Power => DefaultPower;
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
