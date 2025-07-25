﻿using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age > 15)
            {
                Person person = new (name, age);

                Console.WriteLine(person.ToString());
            }

            else if (age >= 0)
            {
                Child child = new(name, age);

                Console.WriteLine(child);
            }

            else
            {
                Console.WriteLine("Age must be positive!");
            }
        }
    }
}