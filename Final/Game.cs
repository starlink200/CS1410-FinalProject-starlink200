using Final;

public struct Game
{
    public readonly Team Team1;
    public readonly Team Team2;

    public readonly bool PlayedGame;

    public Game(Team team1, Team team2, bool playedGame)
    {
        Team1 = team1;
        Team2 = team2;
        PlayedGame = playedGame;
    }

}