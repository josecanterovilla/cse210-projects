using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private static Random _random = new Random();

    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = AskForDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index = (index + 1) % frames.Length;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int number = seconds; number > 0; number--)
        {
            string text = number.ToString();
            Console.Write(text);
            Thread.Sleep(1000);
            Console.Write(new string('\b', text.Length) + new string(' ', text.Length) + new string('\b', text.Length));
        }
    }

    protected int GetSecondsLeft(DateTime endTime)
    {
        double secondsLeft = (endTime - DateTime.Now).TotalSeconds;
        return Math.Max(0, (int)Math.Ceiling(secondsLeft));
    }

    protected string GetRandomUnusedItem(List<string> allItems, List<string> unusedItems)
    {
        if (unusedItems.Count == 0)
        {
            unusedItems.AddRange(allItems);
        }

        int index = _random.Next(unusedItems.Count);
        string item = unusedItems[index];
        unusedItems.RemoveAt(index);
        return item;
    }

    private int AskForDuration()
    {
        int seconds;
        Console.Write("How long, in seconds, would you like for your session? ");

        while (!int.TryParse(Console.ReadLine(), out seconds) || seconds <= 0)
        {
            Console.Write("Please enter a whole number greater than 0: ");
        }

        return seconds;
    }
}
