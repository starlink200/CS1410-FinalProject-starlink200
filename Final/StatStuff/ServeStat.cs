public class ServeStat : Stat
{

    public ServeStat() : base(){}
    public ServeStat(int attempts, int errors, int successes) : base(attempts, errors, successes){}

    public override int GetAttempts()
    {
        Console.WriteLine("How many serve attempts were made?");
        return ValidateAnswer();
    }

    public override int GetErrors()
    {
        Console.WriteLine("How many service errors were made?");
        return ValidateAnswer();
    }

    public override int GetSuccesses()
    {
        Console.WriteLine("How many aces were made?");
        return ValidateAnswer();
    }

}