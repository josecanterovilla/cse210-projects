using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Breathe("Breathe in...", 4, endTime);
            Breathe("Breathe out...", 6, endTime);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private void Breathe(string message, int seconds, DateTime endTime)
    {
        int secondsLeft = GetSecondsLeft(endTime);

        if (secondsLeft > 0)
        {
            Console.Write($"{message} ");
            ShowCountDown(Math.Min(seconds, secondsLeft));
            Console.WriteLine();
        }
    }
}
