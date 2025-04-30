using Final;

public class Tournament
{
    Random rand = new Random();
    public List<Team> Teams = new List<Team>();

    public Tournament()
    {

    }
    public Tournament(List<Team> teams)
    {
        Teams = teams;
    }

    public void AddTeam()
    {
        Teams.Add(new Team(Console.ReadLine()));

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

    void GameSchedule()
    {
        
    }

    void UserOptions()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1: Add Team");
        Console.WriteLine("2: Record Stats");
        Console.WriteLine("3: Record Game Results");
        Console.WriteLine("4: See Game Schedule");
        Console.WriteLine("5: See Pools");
        int temp = ValidateAnswer(1, 5);
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

        }
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
                //AddPlayerStat()
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
        Teams[temp].AddStat();
    }

    void PAddPlayerStat()
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
        temp = ValidateAnswer(1, Teams[temp - 1].Players.Count);
        Teams[temp - 1].Players[temp - 1].AddStat();
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
                    Teams[temp].Pool = i + 1;
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
                if(team.Pool == i + 1)
                {
                    Console.WriteLine($"    {team.Name}");
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