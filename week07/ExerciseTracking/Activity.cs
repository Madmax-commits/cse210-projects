using System;

public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // ABSTRACT METHODS (Required for full polymorphism points)
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual method defined ONCE in base class
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():0.00} km, " +
               $"Speed {GetSpeed():0.00} kph, " +
               $"Pace: {GetPace():0.00} min per km";
    }
}
