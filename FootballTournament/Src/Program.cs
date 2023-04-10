// See https://aka.ms/new-console-template for more information

using ConsoleApp1;
using ConsoleApp1.League;

SetupLeague setup = new SetupLeague();
League league = setup.CreateLeague();

league.Run();

var (teams, name, relegationSpots, championsLeagueSpots, europeLeagueSpots, regularSeason, championship, relegation) = league;
teams.Sort();
teams.Reverse();

PrintTable printTable = new PrintTable(league);
printTable.RegularSeason();
