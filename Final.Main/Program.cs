// See https://aka.ms/new-console-template for more information
using Final;

// Console.WriteLine("Hello, World!");
// List<Team> teams = new List<Team>() {
//     new Team("Lions"), new Team("Tigers"), new Team("Venom"), new Team("GSL"), new Team("Club V"), new Team("801"), new Team("Davis")
// };
// // List<Team> teams = new List<Team>()
// // {
// //     new Team("Lions"), new Team("Tigers"), new Team("Venom"), new Team("GSL")
// // };
// teams[3].AddPlayer("John");
// teams[3].AddPlayer("Joe");
// teams[3].AddPlayer("Job");
// teams[3].AddPlayer("Josh");
// teams[3].AddPlayer("Luke");
// teams[3].AddPlayer("Bobby");
// Tournament myTourney = new Tournament(teams);
// myTourney.Run();
List<Team> teams = new List<Team>
        {
            new Team("A"), new Team("B"), new Team("C"), new Team("D")
        };
foreach(Team team in teams)
{
    Console.Write(team.Name + " ");
}
Tournament tournament = new Tournament(teams);
Tournament tempTournament = tournament;
tournament.Teams[3].matchScores.Add(new MatchScores(2,0));
tournament.Teams[0].matchScores.Add(new MatchScores(0,2));

tournament.SeedTeams();
tournament.SeededPools();
foreach(Team team in tournament.Teams)
{
    Console.Write(team.Name + " ");
}
Console.WriteLine();
foreach(Team team in tempTournament.Teams)
{
    Console.Write(team.Name + " ");
}
