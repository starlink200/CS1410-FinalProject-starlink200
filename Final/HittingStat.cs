using System.Security.Cryptography.X509Certificates;
namespace Final;
public struct HittingStat : IStat
{
    public int Attempts
    {
        get{return Attempts;}
        set{GetAttempts();}
    }
    public int Errors
    {
        get{return Errors;}

        set{GetErrors();}
    }

    public int Successes
    {
        get{return Errors;}
        set{Successes = value;}
    }

    public int GetAttempts()
    {
        Console.WriteLine("How many hitting attempts were made?");
        string answer = Console.ReadLine();
        return Convert.ToInt16(answer);
    }

    public int GetErrors()
    {
        Console.WriteLine("How many hitting errors were made?");
        string answer = Console.ReadLine();
        return Convert.ToInt16(answer);
    }
}