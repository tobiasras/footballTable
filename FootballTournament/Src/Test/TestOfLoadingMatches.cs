using System.Diagnostics;
using ConsoleApp1.League;
using FootballTournament;

namespace ConsoleApp1.Test;

public class TestOfLoadingMatches
{
    TestOfLoadingMatches()
    {
        
    }

    public void Run()
    {
        SetupLeague setupLeague = new SetupLeague();
        var league = setupLeague.CreateLeague();
        Debug.Assert((league.Teams.Count == 10));
        
        league.Run();

        foreach (var leagueTeam in league.Teams)
        {
            Debug.Assert(leagueTeam.Matches.Count == 22);
        }
    }
    
    
}