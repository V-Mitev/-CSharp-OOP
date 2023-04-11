namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly List<Player> playerList;

        public Team(string name)
        {
            Name = name;
            playerList = new List<Player>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (playerList.Any())
                {
                    return playerList.Average(p => p.Stats);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = playerList.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }

            playerList.Remove(player);
        }
    }
}