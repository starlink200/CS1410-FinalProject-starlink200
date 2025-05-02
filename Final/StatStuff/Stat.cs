using System.ComponentModel;

public class Stat
{
    public int Attempts;
    public int Errors;
    public int Successes;
    public double Percentage;

    public Stat()
    {
        Attempts = 0;
        Errors = 0;
        Successes = 0;
    }

    public Stat(int attempts, int errors, int successes)
    {
        Attempts = attempts;
        Errors = errors;
        Successes = successes;
    }

    public void CompileStat()
    {
        int attempts;
        int errors;
        int successes;
        do
        {
            attempts = GetAttempts();
            errors = GetErrors();
            successes = GetSuccesses();
            if(attempts != errors + successes)
            {
                Console.WriteLine("You're errors and successes seem to exceed the number of attempts made, please recheck your information");
            }
            else
            {
                Attempts += attempts;
                Errors += errors;
                Successes += successes;
            }
        }
        while(attempts != errors + successes);
        GetPercentage();
    }

    public int ValidateAnswer()
    {
        int num;
        bool isValid;
        do
        {
            isValid = int.TryParse(Console.ReadLine(), out num);
            if(num < 0)
            {
                isValid = false;
            }
        }
        while(!isValid);
        return num;
    }

    public virtual int GetAttempts(){return 0;}
    public virtual int GetErrors(){return 0;}
    public virtual int GetSuccesses(){return 0;}
    public void GetPercentage()
    {
        Percentage = (double)(Successes - Errors)/Attempts;
    }
}