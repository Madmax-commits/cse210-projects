// Exceeded requirements by:
// 1. Adding a Leveling system (Level = Score / 1000)
// 2. Using polymorphism fully with abstract base class
// 3. Implemented manual serialization system (Factory-style loading)



using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> _goals = new List<Goal>();
    static int _score = 0;

    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine($"Current Score: {_score}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Target Count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus Points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    static void ListGoals()
    {
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetStatus()} {goal.GetName()}");
            i++;
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"You earned {earned} points!");

        CheckLevelUp();
    }

    static void SaveGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    static void LoadGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            if (parts[0] == "SimpleGoal")
            {
                SimpleGoal g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                g.SetComplete(bool.Parse(parts[4]));
                _goals.Add(g);
            }
            else if (parts[0] == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (parts[0] == "ChecklistGoal")
            {
                ChecklistGoal g = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6])
                );

                g.SetProgress(int.Parse(parts[4]));
                _goals.Add(g);
            }
        }
    }

    // 🔥 EXCEEDS REQUIREMENTS: Level System
    static void CheckLevelUp()
    {
        int level = _score / 1000;
        Console.WriteLine($"Current Level: {level}");
    }
}
