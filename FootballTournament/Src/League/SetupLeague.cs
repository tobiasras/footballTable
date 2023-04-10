using ConsoleApp1.Teams;

namespace ConsoleApp1.League
{
    public class SetupLeague
    {
        private FileHandler fileHandler = new FileHandler();

        private League League;

        public SetupLeague()
        {
            League = new League();
            League.Teams = CreateTeams();
            Tuple<int, int, int> rules = GetRules();
        
            League.RelegationSpots = rules.Item1;
            League.EuropeLeagueSpots = rules.Item2;
            League.ChampionsLeagueSpots = rules.Item3;
        }

        private List<Team> CreateTeams()
        {
            string[] files = fileHandler.ReadFile("Files/LeagueSetup/Teams.csv");
            List<Team> teams = new List<Team>();

            for (int i = 1; i < files.Length; i++) // first line is a description not a team
            {
                string csv = files[i];
                string[] strings = csv.Split(";");
                Team team = new Team(strings[0], strings[1]);
                teams.Add(team);
            }

            return teams;
        }

        private Tuple<int, int, int> GetRules()
        {
            String[] files = fileHandler.ReadFile("Files/LeagueSetup/LeagueSetup.csv");

            string csv = files[1];
            string[] strings = csv.Split(";");

            Tuple<int, int, int> tuple = null;
            try
            {
                var relegationSpots = Int32.Parse(strings[0]);
                var europeLeagueSpots = Int32.Parse(strings[2]);
                var championsLeagueSpots = Int32.Parse(strings[1]);
                tuple = Tuple.Create(relegationSpots, europeLeagueSpots, championsLeagueSpots);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error parsing numbers");
            }

            return tuple;
        }


        public League CreateLeague()
        {
            return League;
        }
    }
}