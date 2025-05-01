public class DigStat : Stat
{
    public double DigPercentage;
    public DigStat() : base(){}
    public DigStat(int attempts, int errors, int successes) : base(attempts, errors, successes){}

    public override void GetAttempts()
    {
        Console.WriteLine("How many dig attempts were made?");
        Attempts = ValidateAnswer();
    }

    public override void GetErrors()
    {
        Console.WriteLine("How many dig errors were made?");
        Errors = ValidateAnswer();
    }

    public override void GetSuccesses()
    {
        Console.WriteLine("How many dig were made?");
        Successes = ValidateAnswer();
    }

    public void GetDigPercentage()
    {
        DigPercentage = (Successes - Errors)/Attempts;
    }
}