﻿namespace P04.Recharge
{
    using P04.Recharge.Interfaces;
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }

        
    }
}
