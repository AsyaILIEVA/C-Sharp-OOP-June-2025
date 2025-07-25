﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int warriorPower = 100;

        public Warrior(string name) : base(name, warriorPower)
        {            
        }
        public override string CastAbility()
        => $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
    }
}
