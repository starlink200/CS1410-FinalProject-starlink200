using System.ComponentModel;

public class Stat
{
    public int Attempts;
    public int Errors;
    public int Successes;

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
        do
        {
            GetAttempts();
            GetErrors();
            GetSuccesses();
            if(Attempts != Errors + Successes)
            {
                Console.WriteLine("You're errors and successes seem to exceed the number of attempts made, please recheck your information");
            }
        }
        while(Attempts != Errors + Successes);
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

    public virtual void GetAttempts(){}
    public virtual void GetErrors(){}
    public virtual void GetSuccesses(){}
}