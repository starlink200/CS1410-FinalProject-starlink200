namespace Final;
public class Player
{
    public readonly string Name;
    public readonly string JerseyNum;
    public TrackStat MyStats;

    public Player()
    {
        Name = "No name";
        JerseyNum = "##";
        MyStats = new TrackStat();
    }

    public Player(string name)
    {
        Name = name;
        MyStats = new TrackStat();
    }

    public Player(string name, string jersey)
    {
        Name = name;
        JerseyNum = "#" + jersey;
        MyStats = new TrackStat();
    }

}