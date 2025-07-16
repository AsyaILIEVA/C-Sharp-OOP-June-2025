using P03.Detail_Printer.Interfaces;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents) 
            
        {
            Name = name;
            this.Documents = new List<string> (documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public string Name { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine(Name);
            Console.WriteLine(string.Join(Environment.NewLine, Documents));
        }
    }
}
