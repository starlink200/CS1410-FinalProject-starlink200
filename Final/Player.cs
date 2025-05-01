namespace Final;
public class Player
{
    public readonly string Name;
    public readonly string JerseyNum;
    public HittingStat MyHittingStat;
    public DigStat MyDigStat;
    public SetStat MySetStat;
    public ServeStat MyServeStat;

    public Player()
    {
        Name = "No name";
        JerseyNum = "##";
    }

    public Player(string name)
    {
        Name = name;
    }

    public Player(string name, string jersey)
    {
        Name = name;
        JerseyNum = "#" + jersey;
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
                MyHittingStat.CompileStat();
                break;
            case 2:
                MyServeStat.CompileStat();
                break;
            case 3:
                MyDigStat.CompileStat();
                break;
            case 4:
                MySetStat.CompileStat();
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