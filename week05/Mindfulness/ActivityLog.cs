using System;
using System.IO;
using System.Linq;

public class ActivityLog
{
    private string _filePath;

    public ActivityLog(string filePath)
    {
        _filePath = filePath;
    }

    public void RecordSession(string activityName, int seconds)
    {
        string line = $"{DateTime.Now:yyyy-MM-dd HH:mm}|{activityName}|{seconds}";
        File.AppendAllText(_filePath, line + Environment.NewLine);
    }

    public string GetSummary()
    {
        if (!File.Exists(_filePath))
        {
            return "No activities have been logged yet.";
        }

        var sessions = File.ReadAllLines(_filePath)
            .Select(line => line.Split('|'))
            .Where(parts => parts.Length == 3)
            .ToList();

        string summary = "";
        foreach (var group in sessions.GroupBy(parts => parts[1]))
        {
            int totalSeconds = group.Sum(parts => int.Parse(parts[2]));
            summary += $"{group.Key}: {CountSessions(group.Count())}, {totalSeconds} seconds in total\n";
        }

        int allSeconds = sessions.Sum(parts => int.Parse(parts[2]));
        summary += $"\nAll activities: {CountSessions(sessions.Count)}, {allSeconds} seconds in total";
        return summary;
    }

    private string CountSessions(int count)
    {
        return count == 1 ? "1 session" : $"{count} sessions";
    }
}
