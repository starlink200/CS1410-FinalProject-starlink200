namespace Final;
public class TrackStat
{
    public HittingStat HittingStats;
    public DigStat DigStats;
    public SetStat SetStats;
    public ServeStat ServeStats;

    public TrackStat()
    {
        HittingStats = new HittingStat();
        DigStats = new DigStat();
        ServeStats = new ServeStat();
        SetStats = new SetStat();
    }

    public static void DisplayStats(HittingStat Hit, ServeStat Serve, DigStat Dig, SetStat Set)
    {

        Console.WriteLine($"Serve Attempts: {Serve.Attempts} Service Aces: {Serve.Successes} Service Errors: {Serve.Errors} Serving %: {Serve.ServePercentage}");
        Console.WriteLine($"Hitting Attempts: {Hit.Attempts} Kills: {Hit.Successes} Hitting Errors: {Hit.Errors} Hitting %: {Hit.HittingPercentage}");
        Console.WriteLine($"Dig Attempts: {Dig.Attempts} Digs: {Dig.Successes} Dig Errors: {Dig.Errors} Dig %: {Dig.DigPercentage}");
        Console.WriteLine($"Setting Attempts: {Set.Attempts} Assists: {Set.Successes} Setting Errors: {Set.Errors}");
        Console.WriteLine();
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
                HittingStats.CompileStat();
                break;
            case 2:
                ServeStats.CompileStat();
                break;
            case 3:
                DigStats.CompileStat();
                break;
            case 4:
                SetStats.CompileStat();
                break;
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