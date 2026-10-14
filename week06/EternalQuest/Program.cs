using System;

// Creativity / exceeding requirements:
// - Leveling system: every 1000 points the player levels up and earns a new
//   title (Novice, Apprentice, Adventurer, Hero, Champion, Legend). The level
//   is shown with the score, and a "LEVEL UP!" message appears when it changes.
// - Negative goals: a fourth kind of goal for bad habits. Each time the user
//   records one, they lose points instead of gaining them. They are saved and
//   loaded like the other goals and shown with [!] in the goal list.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
