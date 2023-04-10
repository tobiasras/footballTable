using System.ComponentModel.DataAnnotations;
using FootballTournament;

namespace ConsoleApp1.Teams
{
    public class Team : IComparable<Team>
    {
    public Team(string name, string shortName)
    {
        Name = name;
        ShortName = shortName;
        Matches = new List<Match>();
    }

    public string Name { get; set; }
    public string ShortName { get; set; }
    
    public List<Match> Matches { get; set; }

    public int Wins { get; set; }
    public int Loss { get; set; }
    public int Ties { get; set; }
    public int Points => Wins * 3 + Ties * 1;
    public int Goals { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalsOnAway { get; set; }
    public int GoalDiffrence => Goals - GoalsAgainst;
    
    
    public void AddMatch(Match match)
    {
        Matches.Add(match);
        Goals += match.Goals;
        GoalsAgainst += match.GoalsAgainst;

        if (!match.IsHome)
        {
            ++GoalsOnAway;
        }

        switch (match.Result)
        {
            case Result.Tie:
                ++Ties;
                break;
            case Result.Win:
                ++Wins;
                break;
            case Result.Loss:
                ++Loss;
                break;
        }

        Matches.Sort(((match1, match2) =>
        {
            if (match1.WeekNumber < match2.WeekNumber)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }));
    }

    public int CompareTo(Team? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;

        var pointsComparison = Points.CompareTo(other.Points);
        if (pointsComparison != 0) return pointsComparison;
        
        var goalsDiffComparison = GoalDiffrence.CompareTo(other.GoalDiffrence);
        if (goalsDiffComparison != 0) return goalsDiffComparison;
        
        var goalsComparison = Goals.CompareTo(other.Goals);
        if (goalsComparison != 0) return goalsComparison;
        
        var goalsAwayComparison = GoalsOnAway.CompareTo(other.GoalsOnAway);
        if (goalsAwayComparison != 0) return goalsAwayComparison;
        
        return GoalsOnAway.CompareTo(other.GoalsOnAway);
    }

    public void Deconstruct(out string shortName, out int wins, out int goals)
    {
        shortName = ShortName;
        wins = Wins;
        goals = Goals;
    }
    }
}