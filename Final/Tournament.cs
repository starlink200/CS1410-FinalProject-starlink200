using Final;

public class Tournament
{
    Random rand = new Random();
    public List<Team> Teams = new List<Team>();
    public List<Game> Games = new List<Game>();
    //each pool has 6 games occur during pool play
    public bool FinishPoolPlay => Games.Count == (Teams.Count/4) * 6;
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
        GameSchedule();
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
                RecordGameResults();
                break;
            case 4:
                DisplayPoolPlay();
                break;
            case 5:
                DisplayPools();
                break;
            case 6:
                DisplayStats();
                break;
        }
    }

    void SeedTeams()
    {
        List<Team> SeededTeams = Teams;
        Console.WriteLine("Before");
        foreach(Team team in SeededTeams)
        {
            Console.WriteLine($"{team.Name}");
        }
        for(int i = 0; i < SeededTeams.Count - 1;  i++)
        {
            Team current = SeededTeams[i];
            Team next = SeededTeams[i + 1];
            if(current.GetMatchesWon() < next.GetMatchesWon())
            {
                SeededTeams[i] = next;
                SeededTeams[i+1] = current;
            }
            else if(current.GetSetsWon() < next.GetSetsWon())
            {
                SeededTeams[i] = next;
                SeededTeams[i+1] = current;
            }
            else if(current.GetSetsLost() > next.GetSetsLost())
            {
                SeededTeams[i] = next;
                SeededTeams[i+1] = current;
            }
        }
        Console.WriteLine("after");
        foreach(Team team in SeededTeams)
        {
            Console.WriteLine($"{team.Name}");
        }
    }
    void RecordGameResults()
    {
        int game;
        DisplayPoolPlay();
        do
        {
            Console.WriteLine("Which Game are you adding results for?");
            game = ValidateAnswer(1, 6);
            if(Games[game - 1].PlayedGame)
            {
                Console.WriteLine("Hmm this game already has had its results inputted");
            }
        }
        while(Games[game -1].PlayedGame);
        Console.WriteLine("Which team are you adding the results to");
        Console.WriteLine($"1: {Games[game - 1].Team1.Name}");
        Console.WriteLine($"2: {Games[game - 1].Team2.Name}");
        int team = ValidateAnswer(1, 2);
        int team1Index = Teams.IndexOf(Games[game - 1].Team1);
        int team2Index = Teams.IndexOf(Games[game - 1].Team2);
        int temp;
        int temp2;
        if(team == 1)
        {
            temp = team1Index;
            temp2 = team2Index;
        }
        else
        {
            temp = team2Index;
            temp2 = team1Index;
        }
        Console.WriteLine($"How many sets did {Teams[temp].Name} win?");
        int setsWon = ValidateAnswer(0, 2);
        Console.WriteLine($"How many sets did {Teams[temp].Name} lose?");
        int setsLost = ValidateAnswer(0,2);
        //however many sets one team won the other team had to lose and vice versa
        Teams[temp - 1].matchScores.Add(new MatchScores(setsWon, setsLost));
        Teams[temp2 - 1].matchScores.Add(new MatchScores(setsLost, setsWon));
        int whichGame = Games.IndexOf(new Game(Teams[temp], Teams[temp2]));
        Games[whichGame - 1] = new Game(Teams[temp], Teams[temp2], true);
        
    }

    public void AddTeam()
    {
        int temp;
        Console.WriteLine("Please enter the teams name");
        Teams.Add(new Team(Console.ReadLine()));
        do
        {
            Console.WriteLine("Would you like to add players? 1: Yes 2: No");
            temp = ValidateAnswer(1,2);
            if(temp == 1)
            {
                Teams[Teams.Count-1].AddPlayer();
            }

        }
        while(temp == 1);


    }

    void GameSchedule()
    {
        for(int i = 0; i < Teams.Count; i++)
        {
            for(int j = 0; j < Teams.Count; j++)
            {
                if(Teams[i].Pool == Teams[j].Pool && Teams[i] != Teams[j] && !Games.Contains(new Game(Teams[i], Teams[j])) && !Games.Contains(new Game(Teams[j], Teams[i])))
                {
                    Games.Add(new Game(Teams[i], Teams[j]));
                }
            }
        }
    }

    int DisplayPoolPlay()
    {
        Console.WriteLine("Which pool play games would you like to look at?");
        for(int i = 0; i < Teams.Count/4; i++)
        {
            Console.WriteLine($"Pool {i + 1}");
        }
        int temp = ValidateAnswer(1, Teams.Count/4);
        int j = 1;
        Console.WriteLine($"   Pool {temp} Games");
        Console.WriteLine($"-----------------------");
        foreach(Game game in Games)
        {
            if(temp == 1 && game.Team1.Pool == Pools.Pool1)
            {
                Console.WriteLine($"{j}: {game.Team1.Name} VS {game.Team2.Name}");
                j++;
            }
            else if(temp == 2 && game.Team1.Pool == Pools.Pool2)
            {
                Console.WriteLine($"{j}: {game.Team1.Name} VS {game.Team2.Name}");
                j++;
            }
            else if(temp == 3 && game.Team1.Pool == Pools.Pool3)
            {
                Console.WriteLine($"{j}: {game.Team1.Name} VS {game.Team2.Name}");
                j++;
            }
            else if(temp == 1 && game.Team1.Pool == Pools.Pool4)
            {
                Console.WriteLine($"{j}: {game.Team1.Name} VS {game.Team2.Name}");
                j++;
            }
            
        }
        Console.WriteLine();
        return temp;
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
            if(!isValid)
            {
                Console.WriteLine("Please provide a valid answer");
            }
        }
        while(!isValid);
        return num;
    }
}

//Most tournaments wouldn't have more than 4 pools
public enum Pools {Pool1, Pool2, Pool3, Pool4}