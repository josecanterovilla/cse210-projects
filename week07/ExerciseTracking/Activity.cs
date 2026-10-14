using System;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
        return FormattableString.Invariant(
            $"{_date:dd MMM yyyy} {GetType().Name} ({_lengthInMinutes} min): Distance {GetDistance():F2} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile");
    }
}
