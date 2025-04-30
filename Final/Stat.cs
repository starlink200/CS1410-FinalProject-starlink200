using System.ComponentModel;

public class Stat
{
    public int Attempts;
    public int Errors;
    public int Successes;

    public Stat(){}

    public Stat(int attempts, int errors, int successes)
    {
        Attempts = attempts;
        Errors = errors;
        Successes = successes;
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
}