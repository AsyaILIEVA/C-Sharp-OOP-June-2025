﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public string Username { get; set; }
        public int Level { get; set; }

        public Hero(string name, int level)
        {
            Username = name;
            Level = level;
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
