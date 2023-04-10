# C# construts in use:

## Classes, structs and enums 
I used Enums to descripe wins, losses, and ties in the Matches
I Did not used structs

```
{
    public enum Result
    {
        Win = 'W',
        Tie = 'T',
        Loss = 'L'
    }
}

```




## Properties
in the Team class i used the properties to sort the order of the league
```
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

```



## Tupples, deconstruction
When i had to display the results i deconstruted the Leage class, so it was easeir to use the properties

I used a tupples in the LeagueSetup where i used a tuple to set rules of how many teams was relegaten, and how many went to champions league

```

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


```


## Exception
in the above code example i used exceptions if the string from the csv files where parsable to ints"

## Attributes and DataValidation
i used datavalidation in the League class to be certain that there can only be 10 teams

```
 [Range(10, 10, ErrorMessage = "THERE MUST ONLY BE 10 TEAMS")]
        public List<Team> Teams;
        public string Name { get; set; }
```

## Arrays / Collections
I used the Dictionary collection to store the teams, so it would be easy to fetch the right team.
```
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
```

