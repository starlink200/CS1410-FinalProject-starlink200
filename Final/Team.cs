namespace Final;
public class Team
{
    public readonly string Name;
    public List<Player> Players;
    public HittingStat TotalHittingStat;
    public List<MatchScores> matchScores = new List<MatchScores>();
    public int Pool = 0
    ;

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

    public void AddPlayer(string name = "")
    {
        if(!name.Equals(""))
        {
            Players.Add(new Player(name));
        }
        else
        {
            Players.Add(new Player(GetPlayerName()));
        }
    }

    public string GetPlayerName()
    {
        Console.WriteLine("What is this players name?");
        return Console.ReadLine();
    }

    public void AddStat()
    {
        Console.WriteLine("What kind of stat are we adding?");
        Console.WriteLine("1: Hitting Stats");
        Console.WriteLine("2: Serving Stats");
        Console.WriteLine("3: Defensive Stats");
        Console.WriteLine("4: Setting Stats");
    }

    public void TeamStats()
    {
        foreach(var player in Players)
        {
            TotalHittingStat.Attempts += player.MyHitting.Attempts;
            TotalHittingStat.Errors += player.MyHitting.Attempts;
        }
    }

    int ValidateAnswer(int min, int max)
    {
        int num;
        bool isValid;
        do
        {
            isValid = int.TryParse(Console.ReadLine(), out num);
            if(num < min || num > max)
            {
                isValid = false;
            }
        }
        while(!isValid);
        return num;
    }
}