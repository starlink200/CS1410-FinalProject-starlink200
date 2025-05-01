using System.Security.Cryptography.X509Certificates;
namespace Final;
public class HittingStat : Stat
{
    public double HittingPercentage;
    public HittingStat() : base(){}
    public HittingStat(int attempts, int errors, int successes) : base(attempts, errors, successes){}

    public override void GetAttempts()
    {
        Console.WriteLine("How many hitting attempts were made?");
        Attempts += ValidateAnswer();
    }

    public override void GetErrors()
    {
        Console.WriteLine("How many hitting errors were made?");
        Errors += ValidateAnswer();
    }

    public override void GetSuccesses()
    {
        Console.WriteLine("How many kills were there?");
        Successes += ValidateAnswer();
    }

    public void GetHitPercentage()
    {
        HittingPercentage = (Successes - Errors)/Attempts;
    }
}