namespace Final;
public class Team
{
    public readonly string Name;
    public List<Player> Players;
    public TrackStat TeamStat;
    public List<MatchScores> matchScores = new List<MatchScores>();
    public int Pool = 0
    ;

    public Team()
    {
        Name = "No name";
        Players = new List<Player>();
        TeamStat = new TrackStat();
    }

    public Team(string name)
    {
        Name = name;
        Players = new List<Player>();
        TeamStat = new TrackStat();
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

    public void TeamStats()
    {
        HittingStat tempHit = TeamStat.HittingStats;
        DigStat tempDig = TeamStat.DigStats;
        ServeStat tempServe = TeamStat.ServeStats;
        SetStat tempSet = TeamStat.SetStats;
        foreach(var player in Players)
        {
            //Add hitting stats
            tempHit.Attempts += player.MyStats.HittingStats.Attempts;
            tempHit.Errors += player.MyStats.HittingStats.Errors;
            tempHit.Successes += player.MyStats.HittingStats.Successes;
            //Add digging stats
            tempDig.Attempts += player.MyStats.DigStats.Attempts;
            tempDig.Errors += player.MyStats.DigStats.Errors;
            tempDig.Successes += player.MyStats.DigStats.Successes;
            //add serving stats
            tempServe.Attempts += player.MyStats.ServeStats.Attempts;
            tempServe.Errors += player.MyStats.ServeStats.Errors;
            tempServe.Successes += player.MyStats.ServeStats.Successes;
            //Add setting stats
            tempSet.Attempts += player.MyStats.SetStats.Attempts;
            tempSet.Errors += player.MyStats.SetStats.Errors;
            tempSet.Successes += player.MyStats.SetStats.Successes;
        }
        Console.WriteLine($"  {Name} Stats");
        Console.WriteLine("---------------");
        TrackStat.DisplayStats(tempHit, tempServe, tempDig, tempSet);
        int i = 0;
        foreach(Player player in Players)
        {
            Console.WriteLine($"{i}: {player.Name}");
            i++;
        }
        Console.WriteLine("Type in correlating number to look at a specific players stats. Enter 0 to skip");
        int temp = ValidateAnswer(0, Players.Count);
        if(temp != 0)
        {
            TrackStat temp1 = Players[temp].MyStats;
            Console.WriteLine($"   {Players[temp - 1].Name}'s Stats");
            Console.WriteLine("-------------");
            TrackStat.DisplayStats(temp1.HittingStats, temp1.ServeStats, temp1.DigStats, temp1.SetStats);
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