using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public class HeroFactory
    {
        public static BaseHero CreateHero(string name, string type)
        {
            BaseHero hero;
            if (type == "Druid")
            {
                hero = new Druid(name, type);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name, type);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name, type);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name, type);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero!");
            }

            return hero;
        }
    }
}
