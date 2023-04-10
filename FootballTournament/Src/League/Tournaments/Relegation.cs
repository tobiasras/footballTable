using ConsoleApp1.Teams;
using FootballTournament;

namespace ConsoleApp1.League.Tournaments
{
    public class Relegation : Tournament
    {
    
        public Relegation(List<Team> teams) : base(teams)
        {
        
        }

        public override List<Team> Run()
        {
            throw new NotImplementedException();
        }
    }
}