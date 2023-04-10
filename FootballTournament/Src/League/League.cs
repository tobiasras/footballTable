using System.ComponentModel.DataAnnotations;
using ConsoleApp1.League.Tournaments;
using ConsoleApp1.Teams;

namespace ConsoleApp1.League
{
    public class League
    {
        
        [Range(10, 10, ErrorMessage = "THERE MUST ONLY BE 10 TEAMS")]
        public List<Team> Teams;
        public string Name { get; set; }

        public int RelegationSpots { get; set; }
        public int ChampionsLeagueSpots { get; set; }
        public int EuropeLeagueSpots { get; set; }
    
        public RegularSeason RegularSeason { get; set; }
        public Championship Championship { get; set; }
        public Relegation Relegation { get; set; }
        
        
        

        public void Run()
        {
            RegularSeason = new RegularSeason(Teams);
            Teams = RegularSeason.Run();
            
            Teams.Sort();
            Teams.Reverse();

            var upperTeams = new List<Team>();
            var loverTeams = new List<Team>();

            for (int i = 0; i < Teams.Count; i++)
            {
                if (i < 5)
                {
                    upperTeams.Add(Teams[i]);
                }
                else
                {
                    loverTeams.Add(Teams[i]);
                }
            }
            Championship = new Championship(upperTeams);
            Relegation = new Relegation(loverTeams);
        }
        
        public void Deconstruct(out List<Team> teams, out string name, out int relegationSpots, out int championsLeagueSpots, out int europeLeagueSpots, out RegularSeason regularSeason, out Championship championship, out Relegation relegation)
        {
            teams = Teams;
            name = Name;
            relegationSpots = RelegationSpots;
            championsLeagueSpots = ChampionsLeagueSpots;
            europeLeagueSpots = EuropeLeagueSpots;
            regularSeason = RegularSeason;
            championship = Championship;
            relegation = Relegation;
        }

        public void Deconstruct(out string name, out RegularSeason regularSeason)
        {
            name = Name;
            regularSeason = RegularSeason;
        }
    }
}