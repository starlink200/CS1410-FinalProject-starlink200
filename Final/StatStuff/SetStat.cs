public class SetStat : Stat
{
    public SetStat() : base(){}
    public SetStat(int attempts, int errors, int successes) : base(attempts, errors, successes){}

    public override void GetAttempts()
    {
        Console.WriteLine("How many setting attempts were made?");
        Attempts = ValidateAnswer();
    }

    public override void GetErrors()
    {
        Console.WriteLine("How many setting errors were made?");
        Errors = ValidateAnswer();
    }

    public override void GetSuccesses()
    {
        Console.WriteLine("How many assists were made?");
        Successes = ValidateAnswer();
    }
}