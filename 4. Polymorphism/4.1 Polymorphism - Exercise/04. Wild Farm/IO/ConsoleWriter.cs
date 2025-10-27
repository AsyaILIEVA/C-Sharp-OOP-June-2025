namespace WildFarm.IO
{
    using System;

    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object obj)
            => Console.WriteLine(obj);
    }
}