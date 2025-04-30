namespace Final;
public class Player
{
    public readonly string Name;
    public readonly string JerseyNum;
    public HittingStat MyHitting;

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
    }

}