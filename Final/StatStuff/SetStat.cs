public class SetStat : Stat
{
    public SetStat() : base(){}
    public SetStat(int attempts, int errors, int successes) : base(attempts, errors, successes){}

    public override int GetAttempts()
    {
        Console.WriteLine("How many setting attempts were made?");
        return ValidateAnswer();
    }

    public override int GetErrors()
    {
        Console.WriteLine("How many setting errors were made?");
        return ValidateAnswer();
    }

    public override int GetSuccesses()
    {
        Console.WriteLine("How many assists were made?");
        return ValidateAnswer();
    }
}