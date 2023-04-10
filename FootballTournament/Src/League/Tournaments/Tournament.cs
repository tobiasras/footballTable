using ConsoleApp1.Teams;
using FootballTournament;

namespace ConsoleApp1.League.Tournaments
{
    public abstract class Tournament

    {
        public Dictionary<string, Team> Teams { get; set; }

        
        public Tournament(List<Team> teams)
        {
            Teams = new Dictionary<string, Team>();
            foreach (var team in teams)
            {
                Teams.Add(team.Name, team);
            }
        }
        public abstract List<Team> Run();
    }
}
