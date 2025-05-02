using System.Security.Cryptography.X509Certificates;
namespace Final;
public class HittingStat : Stat
{
    public HittingStat() : base(){}
    public HittingStat(int attempts, int errors, int successes) : base(attempts, errors, successes){}

    public override int GetAttempts()
    {
        Console.WriteLine("How many hitting attempts were made?");
        return ValidateAnswer();
    }

    public override int GetErrors()
    {
        Console.WriteLine("How many hitting errors were made?");
        return ValidateAnswer();
    }

    public override int GetSuccesses()
    {
        Console.WriteLine("How many kills were there?");
        return ValidateAnswer();
    }

}