using Final;

public struct Game
{
    public readonly Team Team1;
    public readonly Team Team2;

    public readonly bool PlayedGame;

    public Game(Team team1, Team team2)
    {
        Team1 = team1;
        Team2 = team2;
        PlayedGame = false;
    }

    public Game(Team team1, Team team2, bool playedGame)
    {
        Team1 = team1;
        Team2 = team2;
        PlayedGame = playedGame;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Game other)) return false;

        // Game is equal if it has the same two teams, in any order
        return (Team1 == other.Team1 && Team2 == other.Team2) ||
            (Team1 == other.Team2 && Team2 == other.Team1);
    }

    public override int GetHashCode()
    {
        int hash1 = Team1?.GetHashCode() ?? 0;
        int hash2 = Team2?.GetHashCode() ?? 0;
        return hash1 ^ hash2;
    }

}