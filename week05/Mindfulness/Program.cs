using System;
using System.IO;
using System.Threading;

// Creativity / exceeding requirements:
// - No prompt or question is repeated until every one of them has been used
//   at least once in the session. When the list runs out, it starts over with
//   all of them again.
// - The program keeps a log of every activity completed. Each session is saved
//   to a file (activity_log.txt), so the log is still there the next time the
//   program runs. Menu option 4 loads the file and shows how many times each
//   activity was done and for how many seconds in total.

class Program
{
    static void Main(string[] args)
    {
        string logPath = Path.Combine(AppContext.BaseDirectory, "activity_log.txt");
        ActivityLog log = new ActivityLog(logPath);

        int choice = 0;
        while (choice != 5)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    log.RecordSession(breathing.GetName(), breathing.GetDuration());
                    break;
                case 2:
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    log.RecordSession(reflecting.GetName(), reflecting.GetDuration());
                    break;
                case 3:
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    log.RecordSession(listing.GetName(), listing.GetDuration());
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Activity Log");
                    Console.WriteLine();
                    Console.WriteLine(log.GetSummary());
                    Console.WriteLine();
                    Console.Write("Press enter to return to the menu.");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 5.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }
}
