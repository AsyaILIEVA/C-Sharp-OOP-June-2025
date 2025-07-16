using P03.Detail_Printer.Interfaces;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IEmployee employee = new Employee("Pesho");

            IEmployee manager = new Manager("Gosho", new List<string>() { "Financial Report", "Project Details" });

            employee.PrintDetails();
            manager.PrintDetails();
        }
    }
}
