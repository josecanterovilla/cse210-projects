using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string[] _levelTitles = { "Novice", "Apprentice", "Adventurer", "Hero", "Champion", "Legend" };
    private int _pointsPerLevel = 1000;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            if (input == null)
            {
                break;
            }

            int.TryParse(input, out choice);

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Keep going on your Eternal Quest. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 6.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {GetLevel()}: {GetLevelTitle()}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal");
        int type = AskForNumber("Which type of goal would you like to create? ", 1, 4);

        string name = AskForText("What is the name of your goal? ");
        string description = AskForText("What is a short description of it? ");

        if (type == 1)
        {
            int points = AskForNumber("What is the amount of points associated with this goal? ", 0, int.MaxValue);
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            int points = AskForNumber("What is the amount of points associated with this goal? ", 0, int.MaxValue);
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            int points = AskForNumber("What is the amount of points associated with each time you accomplish it? ", 0, int.MaxValue);
            int target = AskForNumber("How many times does this goal need to be accomplished for a bonus? ", 1, int.MaxValue);
            int bonus = AskForNumber("What is the bonus for accomplishing it that many times? ", 0, int.MaxValue);
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            int points = AskForNumber("How many points do you lose each time you do this? ", 0, int.MaxValue);
            _goals.Add(new NegativeGoal(name, description, points));
        }

        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Create one first.");
            return;
        }

        ListGoalNames();
        int number = AskForNumber("Which goal did you accomplish? ", 1, _goals.Count);
        Goal goal = _goals[number - 1];

        if (goal.IsComplete())
        {
            Console.WriteLine("That goal is already complete, so it earns no more points.");
            return;
        }

        int levelBefore = GetLevel();
        int points = goal.RecordEvent();
        _score += points;

        if (points >= 0)
        {
            Console.WriteLine($"Congratulations! You have earned {points} points!");
        }
        else
        {
            Console.WriteLine($"Oh no! You lost {-points} points.");
        }

        Console.WriteLine($"You now have {_score} points.");

        if (GetLevel() > levelBefore)
        {
            Console.WriteLine($"LEVEL UP! You are now level {GetLevel()}: {GetLevelTitle()}!");
        }
    }

    public void SaveGoals()
    {
        string filename = AskForText("What is the filename for the goal file? ");

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Saved {_goals.Count} goals to {filename}.");
    }

    public void LoadGoals()
    {
        string filename = AskForText("What is the filename for the goal file? ");

        if (!File.Exists(filename))
        {
            Console.WriteLine($"The file {filename} does not exist.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            int loadedScore = int.Parse(lines[0]);

            List<Goal> loadedGoals = new List<Goal>();
            for (int i = 1; i < lines.Length; i++)
            {
                loadedGoals.Add(CreateGoalFromString(lines[i]));
            }

            _score = loadedScore;
            _goals = loadedGoals;
            Console.WriteLine($"Loaded {_goals.Count} goals from {filename}.");
        }
        catch (Exception)
        {
            Console.WriteLine("That file could not be read. It may not be a goal file.");
        }
    }

    private Goal CreateGoalFromString(string line)
    {
        string[] typeAndDetails = line.Split(':', 2);
        string type = typeAndDetails[0];
        string[] parts = typeAndDetails[1].Split('|');

        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
            case "EternalGoal":
                return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
            case "ChecklistGoal":
                return new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[4]), int.Parse(parts[3]), int.Parse(parts[5]));
            case "NegativeGoal":
                return new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]));
            default:
                throw new FormatException($"Unknown goal type: {type}");
        }
    }

    private int GetLevel()
    {
        return Math.Max(0, _score) / _pointsPerLevel + 1;
    }

    private string GetLevelTitle()
    {
        int index = Math.Min(GetLevel() - 1, _levelTitles.Length - 1);
        return _levelTitles[index];
    }

    private string AskForText(string prompt)
    {
        Console.Write(prompt);
        string text = Console.ReadLine();
        return text == null ? "" : text.Replace("|", "/").Trim();
    }

    private int AskForNumber(string prompt, int minimum, int maximum)
    {
        int number;
        Console.Write(prompt);

        while (!int.TryParse(Console.ReadLine(), out number) || number < minimum || number > maximum)
        {
            Console.Write("Please enter a valid whole number: ");
        }

        return number;
    }
}
