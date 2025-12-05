namespace _05._Football_Team_Generator
{
    internal class StartUp
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmd = input.Split(';');

                    if (cmd[0] == "Team")
                    {
                        teams.Add(new Team(cmd[1]));
                    }
                    else if (cmd[0] == "Add")
                    {
                        string teamName = cmd[1];
                        Team thisTeam = FindTeamIfItExists(teams, teamName);
                        Player thisPlayer = new Player(cmd[2], int.Parse(cmd[3]), int.Parse(cmd[4]), int.Parse(cmd[5]), int.Parse(cmd[6]), int.Parse(cmd[7]));
                        thisTeam.AddPlayer(thisPlayer);
                    }
                    else if (cmd[0] == "Remove")
                    {
                        string teamName = cmd[1];
                        Team thisTeam = FindTeamIfItExists(teams, teamName);
                        thisTeam.RemovePlayer(cmd[2]);
                    }
                    else if (cmd[0] == "Rating")
                    {
                        string teamName = cmd[1];
                        Team thisTeam = FindTeamIfItExists(teams, teamName);
                        Console.WriteLine($"{thisTeam.Name} - {thisTeam.Rating}");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static Team FindTeamIfItExists(List<Team> teams, string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
                throw new ArgumentException($"Team {teamName} does not exist.");
            return teams.Find(t => t.Name == teamName);
        }
    }
}