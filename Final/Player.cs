public class Player
{
    readonly string Name;
    readonly string JerseyNum;
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


}