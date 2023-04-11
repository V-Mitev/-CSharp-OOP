namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const int minSkill = 0;
        private const int maxSkill = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public int Endurance
        {
            get => endurance;
            private set
            {
                if (minSkill > value || value > maxSkill)
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }

                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                if (minSkill > value || value > maxSkill)
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }

                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                if (minSkill > value || value > maxSkill)
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }

                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                if (minSkill > value || value > maxSkill)
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }

                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                if (minSkill > value || value > maxSkill)
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }

                shooting = value;
            }
        }

        public double Stats => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
    }
}