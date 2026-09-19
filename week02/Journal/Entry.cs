public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        int wordCount = _entryText.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine($"{_date}: {_promptText}");
        Console.WriteLine($"{_entryText} ({wordCount} words)");
        Console.WriteLine();
    }

    public string ToFileLine()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split('|', 3);
        return new Entry(parts[0], parts[1], parts[2]);
    }
}
