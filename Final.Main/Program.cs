// See https://aka.ms/new-console-template for more information
using Final;

Console.WriteLine("Hello, World!");
// List<Team> teams = new List<Team>() {
//     new Team("Lions"), new Team("Tigers"), new Team("Venom"), new Team("GSL"), new Team("Club V"), new Team("801"), new Team("Davis"),
//     new Team("MTN Green")
// };
List<Team> teams = new List<Team>()
{
    new Team("Lions"), new Team("Tigers"), new Team("Venom"), new Team("GSL")
};
teams[3].AddPlayer("John");
teams[3].AddPlayer("Joe");
teams[3].AddPlayer("Job");
teams[3].AddPlayer("Josh");
teams[3].AddPlayer("Luke");
teams[3].AddPlayer("Bobby");
Tournament myTourney = new Tournament(teams);
myTourney.Run();
