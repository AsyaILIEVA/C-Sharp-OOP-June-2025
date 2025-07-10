using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IIdentifiable> society = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {  
            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IIdentifiable identifiable;

            if (tokens.Length == 3)
            {
                identifiable = new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2]);                
            }
            else
            {
                identifiable = new Robots(tokens[0], tokens[1]);                
            }

            society.Add(identifiable);
        }

        string invalidSuffix = Console.ReadLine();
        
        foreach (IIdentifiable member in society)
        {
            if (member.Id.EndsWith(invalidSuffix))
            {
                Console.WriteLine(member.Id);
            }
        }
    }
}