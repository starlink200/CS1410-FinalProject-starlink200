public class ServeStat : Stat
{
    public double ServePercentage;

    public ServeStat() : base(){}
    public ServeStat(int attempts, int errors, int successes) : base(attempts, errors, successes){}

    public override void GetAttempts()
    {
        Console.WriteLine("How many serve attempts were made?");
        Attempts = ValidateAnswer();
    }

    public override void GetErrors()
    {
        Console.WriteLine("How many service errors were made?");
        Errors = ValidateAnswer();
    }

    public override void GetSuccesses()
    {
        Console.WriteLine("How many aces were made?");
        Successes = ValidateAnswer();
    }

    public void GetServePercentage()
    {
        ServePercentage = (Successes - Errors)/Attempts;
    }
}