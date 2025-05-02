using System.Collections.Generic;
using NUnit;
using Final;

public class TournamentTests
{
    [Test]
    public void FinishPoolPlay_ReturnsTrue_WhenExpectedGameCountReached()
    {
        List<Team> teams = new List<Team>
        {
            new Team("A"), new Team("B"), new Team("C"), new Team("D")
        };
        Tournament tournament = new Tournament(teams);
        
        // Simulate 6 games (1 pool of 4 teams -> 6 games)
        for (int i = 0; i < 6; i++)
        {
            tournament.PoolPlayGames.Add(new Game(teams[0], teams[1]));
        }

        Assert.True(tournament.FinishedPoolPlay());
    }

    [Test]
    public void GameSchedule_CreatesCorrectNumberOfGames()
    {
        Team team1 = new Team("A") { Pool = Pools.Pool1 };
        Team team2 = new Team("B") { Pool = Pools.Pool1 };
        Team team3 = new Team("C") { Pool = Pools.Pool1 };
        Team team4 = new Team("D") { Pool = Pools.Pool1 };
        Tournament tournament = new Tournament(new List<Team> { team1, team2, team3, team4 });

        tournament.PoolPlaySchedule();

        // In a round robin of 4 teams, there should be 6 games
        Assert.AreEqual(6, tournament.PoolPlayGames.Count);
    }
}
