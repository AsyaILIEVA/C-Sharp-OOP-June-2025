using System;
using Telephony.Models;
using Telephony.Models.Interfaces;

public class StartUp
{
    public static void Main(string[] args)
    {
        string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (var phoneNumber in phoneNumbers)
        {
            ICallable callable;

            if (phoneNumber.Length == 10)
            {
                callable = new SmartPhone();
            }
            else
            {
                callable = new StationaryPhone();
            }

            try
            {
                Console.WriteLine(callable.Call(phoneNumber));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        IBrowsable browsable = new SmartPhone();

        foreach (var url in urls)
        {
            try
            {
                Console.WriteLine(browsable.Browse(url));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}