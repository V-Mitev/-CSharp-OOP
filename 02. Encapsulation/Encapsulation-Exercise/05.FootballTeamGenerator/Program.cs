using _05.FootballTeamGenerator;

List<Team> teamList = new List<Team>();

string input = Console.ReadLine();

while (input != "END")
{
    string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

    string command = tokens[0];

    try
    {
        if (command == "Team")
        {
            string teamName = tokens[1];

            AddTeam(teamName, teamList);
        }
        else if (command == "Add")
        {
            string teamName = tokens[1];
            string playerName = tokens[2];
            int endurance = int.Parse(tokens[3]);
            int sprint = int.Parse(tokens[4]);
            int dribble = int.Parse(tokens[5]);
            int passing = int.Parse(tokens[6]);
            int shooting = int.Parse(tokens[7]);

            AddPlayer(teamName, playerName, endurance, sprint, dribble, passing, shooting, teamList);
        }
        else if (command == "Remove")
        {
            string teamName = tokens[1];
            string playerName = tokens[2];

            RemovePlayer(teamName, playerName, teamList);
        }
        else if (command == "Rating")
        {
            string teamName = tokens[1];

            PrintRating(teamName, teamList);
        }
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine(ae.Message);
    }

    input = Console.ReadLine();
}

static void AddTeam(string name, List<Team> teams)
{
    teams.Add(new Team(name));
}

static void AddPlayer(
    string teamName,
    string name,
    int endurance,
    int sprint,
    int dribble,
    int passing,
    int shooting,
    List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team == null)
    {
        Console.WriteLine($"Team {teamName} does not exist.");

        return;
    }

    Player player = new(name, endurance, sprint, dribble, passing, shooting);
    team.AddPlayer(player);
}

static void RemovePlayer(string teamName, string playerName, List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team == null)
    {
        Console.WriteLine($"Team {teamName} does not exist.");

        return;
    }

    team.RemovePlayer(playerName);
}

static void PrintRating(string teamName, List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team == null)
    {
        Console.WriteLine($"Team {teamName} does not exist.");

        return;
    }

    Console.WriteLine($"{teamName} - {team.Rating:f0}");
}