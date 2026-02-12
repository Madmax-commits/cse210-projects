public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        // If already complete, do not allow further progress
        if (_amountCompleted >= _target)
        {
            return 0;
        }

        _amountCompleted++;

        // If goal just reached completion, award bonus
        if (_amountCompleted == _target)
        {
            return _points + _bonus;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetStatus()
    {
        return $"[{(_amountCompleted >= _target ? "X" : " ")}] Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
    }

    public void SetProgress(int completed)
    {
        // Ensure loaded progress never exceeds target
        _amountCompleted = completed > _target ? _target : completed;
    }
}
