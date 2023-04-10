namespace FootballTournament
{
    public class Match
    {
        public int WeekNumber { get; set; }
        public int Goals { get; set; }
        public int GoalsAgainst { get; set; }
        public Result Result { get; set; }
        public bool IsHome { get; set; }
        public string Opponent { get; set; }
        
        public Match(int goals, int goalsAgainst, bool isHome, string opponent, int weekNumber)
        {
            Goals = goals;
            GoalsAgainst = goalsAgainst;
            WeekNumber = weekNumber;

            if (goals > goalsAgainst)
            {
                Result = Result.Win;
            }
            else if (goals == goalsAgainst)
            {
                Result = Result.Tie;
            }
            else
            {
                Result = Result.Loss;
            }
            
            IsHome = isHome;
            Opponent = opponent;
        }

        
    }
}