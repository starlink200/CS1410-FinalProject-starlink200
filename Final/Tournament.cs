using Final;

public class Tournament
{
    Random rand = new Random();
    public List<Team> Teams {get; private set;}
    public List<Game> PoolPlayGames {get; private set;}
    public List<Game> EliminationGames {get; private set;}
    private List<Team> AdvancingTeams = new List<Team>();
    //each pool has 6 games occur during pool play
    //public bool FinishPoolPlay => PoolPlayGames.Count == (Teams.Count/4) * 6;
    public bool EndTournament => EliminationGames.Count == 1;
    public Tournament()
    {
        Teams = new List<Team>();
        PoolPlayGames = new List<Game>();
        EliminationGames = new List<Game>();
    }
    public Tournament(List<Team> teams)
    {
        Teams = teams;
        PoolPlayGames = new List<Game>();
        EliminationGames = new List<Game>();
    }


    public void Run()
    {
        bool quit = false;
        bool eliminationScheduled = false;
        SplitIntoPoolPlay();
        PoolPlaySchedule();
        while(!quit)
        {
            UserOptions();
            if(EndTournament)
            {
                Console.WriteLine($"Congratulations {Teams[0]}! Your team won the tournament!");
                quit = true;
            }
            if(FinishedPoolPlay() && !eliminationScheduled)
            {
                SeedTeams();
                SeededPools();
                ElimationSchedule();
                eliminationScheduled = true;
            }
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
                if(FinishedPoolPlay())
                {
                    RecordGameResults(EliminationGames);
                }
                else
                {
                    RecordGameResults(PoolPlayGames);
                }
                break;
            case 4:
                if(FinishedPoolPlay())
                {
                    DisplayGames(EliminationGames);
                }
                else
                {
                    DisplayGames(PoolPlayGames);
                }
                break;
            case 5:
                DisplayPools();
                break;
            case 6:
                DisplayStats();
                break;
        }
        
    }
    public bool FinishedPoolPlay()
    {
        int i = 0;
        foreach(Game game in PoolPlayGames)
        {
            if(game.PlayedGame)
            {
                i++;
            }
        }
        return i == Teams.Count/4 * 6;
    }

    void ElimationSchedule()
    {
        EliminationGames.Clear();
        for(int i = 0; i < Teams.Count / 4; i++)
        {
            EliminationGames.Add(new Game(Teams[i*4], Teams[i*4 + 3]));
            EliminationGames.Add(new Game(Teams[i*4 + 1], Teams[i*4 + 2]));
        }
    }


    public void SeedTeams()
    {
        Teams.Sort((team1, team2) =>
        {
            int compareMatches = team2.GetMatchesWon().CompareTo(team1.GetMatchesWon());
            if (compareMatches != 0)
            {
                return compareMatches;
            }

            int compareSetsWon = team2.GetSetsWon().CompareTo(team1.GetSetsWon());
            if (compareSetsWon != 0)
            {
                return compareSetsWon;
            }

            return team1.GetSetsLost().CompareTo(team2.GetSetsLost());
        });

    }

    public void SeededPools()
    {
        for(int i = 0; i < Teams.Count; i++)
        {
            if(i < 4)
            {
                Teams[i].Pool = Pools.Pool1;
            }
            else if(i >= 4 && i < 8)
            {
                Teams[i].Pool = Pools.Pool2;
            }
            else if(i >= 8 && i < 12)
            {
                Teams[i].Pool = Pools.Pool3;
            }
            else if(i >= 12 && i < 16)
            {
                Teams[i].Pool = Pools.Pool4;
            }
        }
    }
    void RecordGameResults(List<Game> games)
    {
        int game;
        DisplayGames(games);
        do
        {
            Console.WriteLine("Which Game are you adding results for?");
            game = ValidateAnswer(1, games.Count);
            if(games[game - 1].PlayedGame)
            {
                Console.WriteLine("Hmm this game already has had its results inputted");
            }
        }
        while(games[game -1].PlayedGame);

        int team1Index = Teams.IndexOf(games[game - 1].Team1);
        int team2Index = Teams.IndexOf(games[game - 1].Team2);

        Console.WriteLine($"How many sets did {Teams[team1Index].Name} win?");
        int setsWon = ValidateAnswer(0, 2);
        Console.WriteLine($"How many sets did {Teams[team1Index].Name} lose?");
        int setsLost = ValidateAnswer(0,2);
        //however many sets one team won the other team had to lose and vice versa
        Teams[team1Index].matchScores.Add(new MatchScores(setsWon, setsLost));
        Teams[team2Index].matchScores.Add(new MatchScores(setsLost, setsWon));
        int whichGame = games.IndexOf(new Game(Teams[team1Index], Teams[team2Index]));
        if( whichGame != -1)
        {
            games[whichGame] = new Game(Teams[team1Index], Teams[team2Index], true);
        }
        else
        {
            Console.WriteLine("Could not be found");
        }
        if(FinishedPoolPlay())
        {
            Team winner;
            if(Teams[team1Index].matchScores.Last().WonMatch)
            {
                winner = Teams[team1Index];
            }
            else
            {
                winner = Teams[team2Index];
            }
            AdvancingTeams.Add(winner);
            if (AdvancingTeams.Count == Teams.Count / 2)
            {
                Teams = new List<Team>(AdvancingTeams);
                AdvancingTeams.Clear();
            }

            EliminationGames = games;
        }
        else
        {
            PoolPlayGames = games;
        }
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
        for(int i = 0; i < Teams.Count; i++)
        {
            Teams[i].Pool = 0;
        }
        PoolPlayGames = new List<Game>();
        SplitIntoPoolPlay();
        PoolPlaySchedule();
    }

    public void PoolPlaySchedule()
    {
        for(int i = 0; i < Teams.Count; i++)
        {
            for(int j = 0; j < Teams.Count; j++)
            {
                if(Teams[i].Pool == Teams[j].Pool && Teams[i] != Teams[j] && !PoolPlayGames.Contains(new Game(Teams[i], Teams[j])) && !PoolPlayGames.Contains(new Game(Teams[j], Teams[i])))
                {
                    PoolPlayGames.Add(new Game(Teams[i], Teams[j]));
                }
            }
        }
    }


    void DisplayGames(List<Game> games)
    {
        Console.WriteLine("Which games would you like to look at?");
        for(int i = 0; i < Teams.Count/4; i++)
        {
            Console.WriteLine($"Pool {i + 1}");
        }
        int temp = ValidateAnswer(1, Teams.Count/4);
        int j = 1;
        Console.WriteLine($"   Pool {temp} Games");
        Console.WriteLine($"-----------------------");
        foreach(Game game in games)
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
            else if(temp == 4 && game.Team1.Pool == Pools.Pool4)
            {
                Console.WriteLine($"{j}: {game.Team1.Name} VS {game.Team2.Name}");
                j++;
            }
            
        }
        Console.WriteLine();
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
        
        int temp2 = ValidateAnswer(1, Teams[temp - 1].Players.Count);
        Teams[temp - 1].Players[temp2 - 1].MyStats.AddStat();
    }

    public void SplitIntoPoolPlay()
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