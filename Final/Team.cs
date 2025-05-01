namespace Final;
public class Team
{
    public readonly string Name;
    public List<Player> Players;
    public HittingStat TeamHittingStat;
    public DigStat TeamDigStat;
    public SetStat TeamSetStat;
    public ServeStat TeamServeStat;
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
        int temp = ValidateAnswer(1, 4);
        switch(temp)
        {
            case 1:
                TeamHittingStat.CompileStat();
                break;
            case 2:
                TeamServeStat.CompileStat();
                break;
            case 3:
                TeamDigStat.CompileStat();
                break;
            case 4:
                TeamSetStat.CompileStat();
                break;
        }
    }

    public void TeamStats()
    {
        foreach(var player in Players)
        {
            //Add hitting stats
            TeamHittingStat.Attempts += player.MyHittingStat.Attempts;
            TeamHittingStat.Errors += player.MyHittingStat.Errors;
            TeamHittingStat.Successes += player.MyHittingStat.Successes;
            //Add digging stats
            TeamDigStat.Attempts += player.MyDigStat.Attempts;
            TeamDigStat.Errors += player.MyDigStat.Errors;
            TeamDigStat.Successes += player.MyDigStat.Successes;
            //add serving stats
            TeamServeStat.Attempts += player.MyServeStat.Attempts;
            TeamServeStat.Errors += player.MyServeStat.Errors;
            TeamServeStat.Successes += player.MyServeStat.Successes;
            //Add setting stats
            TeamSetStat.Attempts += player.MySetStat.Attempts;
            TeamSetStat.Errors += player.MySetStat.Errors;
            TeamSetStat.Successes += player.MySetStat.Successes;
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