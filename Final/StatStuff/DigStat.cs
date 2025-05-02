public class DigStat : Stat
{
    public DigStat() : base(){}
    public DigStat(int attempts, int errors, int successes) : base(attempts, errors, successes){}

    public override int GetAttempts()
    {
        Console.WriteLine("How many dig attempts were made?");
        return ValidateAnswer();
    }

    public override int GetErrors()
    {
        Console.WriteLine("How many dig errors were made?");
        return ValidateAnswer();
    }

    public override int GetSuccesses()
    {
        Console.WriteLine("How many dig were made?");
        return ValidateAnswer();
    }

}