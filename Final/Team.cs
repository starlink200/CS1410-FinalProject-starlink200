public class Team
{
    readonly string Name;
    public List<Player> Players;
    public HittingStat TotalHittingStat;

    public Team()
    {
        Name = "No name";
        Players = new List<Player>();
    }

    public Team(string name)
    {
        Name = name;
        Players = new List<Player>();
    }

    public void AddPlayer()
    {
        Players.Add(new Player(GetPlayerName()));
    }

    public string GetPlayerName()
    {
        Console.WriteLine("What is this players name?");
        return Console.ReadLine();
    }

    public void TeamStats()
    {
        foreach(var player in Players)
        {
            TotalHittingStat.Attempts += player.MyHitting.Attempts;
            TotalHittingStat.Errors += player.MyHitting.Attempts;
        }
    }
}