using Final;

public class Tournament
{
    Random rand = new Random();
    public List<Team> Teams = new List<Team>();
    public List<Game> Games = new List<Game>();
    public Tournament()
    {

    }
    public Tournament(List<Team> teams)
    {
        Teams = teams;
    }


    public void Run()
    {
        bool quit = false;
        SplitIntoPoolPlay();
        while(!quit)
        {
            UserOptions();
        }
    }

    void UserOptions()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1: Add Team");
        Console.WriteLine("2: Record Stats");
        Console.WriteLine("3: Record Game Results");
        Console.WriteLine("4: See Game Schedule");
        Console.WriteLine("5: See Pools");
        Console.WriteLine("6: Display Stats");
        int temp = ValidateAnswer(1, 6);
        switch(temp)
        {
            case 1:
                AddTeam();
                break;
            case 2:
                WhichStats();
                break;
            case 3:
                //RecordGameResults();
                break;
            case 4:
                //GameSchedule();
                break;
            case 5:
                DisplayPools();
                break;
            case 6:
                DisplayStats();
                break;
        }
    }
    public void AddTeam()
    {
        Teams.Add(new Team(Console.ReadLine()));

    }

    void GameSchedule()
    {
        
    }

    void DisplayStats()
    {
        Console.WriteLine("Which Team are you wanting to look at stats for?");
        int i = 1;
        foreach(Team team in Teams)
        {
            Console.WriteLine($"{i}: {team.Name}");
            i++;
        }
        int temp = ValidateAnswer(1, Teams.Count);
        Teams[temp - 1].TeamStats();
    }

    void WhichStats()
    {
        Console.WriteLine("What kind of stats are being recorded? 1: Team Stats 2: Player Stats");
        int temp = ValidateAnswer(1, 2);
        switch(temp)
        {
            case 1:
                AddTeamStat();
                break;
            case 2:
                AddPlayerStat();
                break;
        }
    }

    void AddTeamStat()
    {
        Console.WriteLine("Which Team are you adding stats for?");
        int i = 1;
        foreach(Team team in Teams)
        {
            Console.WriteLine($"{i}: {team.Name}");
            i++;
        }
        int temp = ValidateAnswer(1, Teams.Count);
        Teams[temp - 1].TeamStat.AddStat();
    }

    void AddPlayerStat()
    {
        Console.WriteLine("Which Team is your player on?");
        int i = 1;
        foreach(Team team in Teams)
        {
            Console.WriteLine($"{i}: {team.Name}");
            i++;
        }
        int temp = ValidateAnswer(1, Teams.Count);
        i = 1;
        Console.WriteLine("Which player are you adding stats for?");
        foreach(Player player in Teams[temp - 1].Players)
        {
            Console.WriteLine($"{i}: {player.Name}");
            i++;
        }
        
        int temptemp = ValidateAnswer(1, Teams[temp - 1].Players.Count);
        Teams[temp - 1].Players[temptemp - 1].MyStats.AddStat();
    }

    void SplitIntoPoolPlay()
    {
        //4 teams in each pool
        int HowManyPools = Teams.Count / 4;
        for(int i = 0; i < HowManyPools; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                int temp = rand.Next(Teams.Count);
                if(Teams[temp].Pool == 0)
                {
                    switch(i)
                    {
                        case 0:
                            Teams[temp].Pool = Pools.Pool1;
                            break;
                        case 1:
                            Teams[temp].Pool = Pools.Pool2;
                            break;
                        case 2:
                            Teams[temp].Pool = Pools.Pool3;
                            break;
                        case 3:
                            Teams[temp].Pool = Pools.Pool4;
                            break;
                    }
                }
                else
                {
                    j--;
                }
            }
        }
    }

    public void DisplayPools()
    {
        for(int i = 0; i < Teams.Count / 4; i++)
        {
            Console.WriteLine($"    Pool {i + 1}");
            Console.WriteLine("--------------");
            foreach(Team team in Teams)
            {
                switch(i)
                {
                    case 0:
                        if(team.Pool == Pools.Pool1)
                        {
                            Console.WriteLine($"   {team.Name}");
                        }
                        break;
                    case 1:
                        if(team.Pool == Pools.Pool2)
                        {
                            Console.WriteLine($"   {team.Name}");
                        }
                        break;
                    case 2:
                        if(team.Pool == Pools.Pool3)
                        {
                            Console.WriteLine($"   {team.Name}");
                        }
                        break;
                    case 3:
                        if(team.Pool == Pools.Pool4)
                        {
                            Console.WriteLine($"   {team.Name}");
                        }
                        break;
                }
            }
            Console.WriteLine();
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

//Most tournaments wouldn't have more than 4 pools
public enum Pools {Pool1, Pool2, Pool3, Pool4}