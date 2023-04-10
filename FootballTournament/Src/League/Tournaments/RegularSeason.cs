using ConsoleApp1;
using ConsoleApp1.Teams;
using FootballTournament;

namespace ConsoleApp1.League.Tournaments
{
    public class RegularSeason : Tournament
    {
        
        public RegularSeason(List<Team> teams) : base(teams)
        {
        }
        
        public override List<Team> Run()
        {
            var fileHandler = new FileHandler();
            List<string[]> weeksOfMatches = fileHandler.ReadFiles("Files/RegularSeasonWeeks");

            foreach (var week in weeksOfMatches)
            {
                Week(week);
            }
            return new List<Team>(Teams.Values);
        }

        public void Week(string[] matches)
        {
            for (int i = 1; i < matches.Length; i++)
            {
                var firstLine = matches[0].Split(";");
                int weekNumber = Int32.Parse(firstLine[4]);
                
                string matchCSV = matches[i]; // Midtjylland;Randers;1;0

                var strings = matchCSV.Split(";");

                string hometeam = strings[0];
                string awayTeam = strings[1];
                
                int goalsHome = Int32.Parse(strings[2]);
                int goalsAway = Int32.Parse(strings[3]);

                Match home = new Match(goalsHome, goalsAway, true, awayTeam, weekNumber);
                Match away = new Match(goalsAway, goalsHome, false, hometeam, weekNumber);

                Teams[hometeam].AddMatch(home);
                Teams[awayTeam].AddMatch(away);
            }
        }
    }
}