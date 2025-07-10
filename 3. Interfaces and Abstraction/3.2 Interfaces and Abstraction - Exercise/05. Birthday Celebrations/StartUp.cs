using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IBirthable> society = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = tokens[0];
            IBirthable birthable = default;

            switch (type)
            {
                case "Citizen":
                    birthable = new Citizens(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    society.Add(birthable);
                    break;
                case "Pet":
                    birthable = new Pet(tokens[1], tokens[2]);
                    society.Add(birthable);
                    break;
                default:
                    break;
            }           
        }    

    string year = Console.ReadLine();

        foreach (IBirthable member in society)
        {
            if (member.Birthdate.EndsWith(year))
            {
                Console.WriteLine(member.Birthdate);
            }
        }
    }
}