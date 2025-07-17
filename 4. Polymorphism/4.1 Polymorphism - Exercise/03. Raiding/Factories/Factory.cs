using Raiding.Exceptions;
using Raiding.Factories.Interfaces;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public class Factory: IFactory
    {
        public BaseHero CreateHero(string type, string name) 
        {
            BaseHero hero;

            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.INVALID_HERO_EXCEPTION_MESSAGE);
                    
            }

            return hero;

        }
    }
}
