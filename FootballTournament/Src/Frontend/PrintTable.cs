using ConsoleApp1.League.Tournaments;
using ConsoleApp1.Teams;

namespace ConsoleApp1
{
    public class PrintTable
    {
        private League.League League;

        public PrintTable(League.League league)
        {
            League = league;
        }

        public void RegularSeason()
        {
            var (name, regularSeason) = League;
            List<Team> teams = new List<Team>(regularSeason.Teams.Values);
            teams.Sort();
            teams.Reverse();

            Console.WriteLine($"Pos\tTeam\tPoints\tWins\tTies\tLoss\tGoals\tG.Dif\tLast 5 Games");
            
            for (int i = 0; i < teams.Count; i++)
            {
                Team team = teams[i];
                
                if (i < 6) // winners
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    PrintTeam(team, i);
                }
                else // lossers
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintTeam(team, i);
                    
                }
            }
        }

        private void PrintTeam(Team team, int i)
        {
            Console.Write($"{i+1}:\t{team.ShortName}\t{team.Points}\t{team.Wins}\t{team.Ties}\t{team.Loss}\t{team.Goals}\t{team.GoalDiffrence}");
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"\t{team.Matches[j].Result}");
            }
            Console.WriteLine();
        }
        

    }
}