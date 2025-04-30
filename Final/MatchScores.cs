public readonly struct MatchScores
{
    public readonly int SetsWon;
    public readonly int SetsLost;

    public MatchScores(int setsWon, int setsLost)
    {
        SetsWon = setsWon;
        SetsLost = setsLost;
    }
    public bool WonMatch => SetsWon > SetsLost;
}