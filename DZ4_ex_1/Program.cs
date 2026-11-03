using System.Collections.Generic;
using System;

List<Team> teams = new List<Team>();

Console.Write("Enter team name: ");
string teamName = Console.ReadLine();
teams.Add(new Team(teamName));

while (true)
{
    for (int i = 0; i < teams.Count; i++)
    {
        if (i > 0)
        {
            Console.Write(", ");
        }
        Console.Write($"{i + 1}. - {teams[i].Name}");
    }
    Console.WriteLine();
    Console.Write("Select team: ");
    int teamIndex = Convert.ToInt32(Console.ReadLine()) - 1;

    if (teamIndex < 0 || teamIndex >= teams.Count)
    {
        Console.WriteLine("Invalid team number");
        continue;
    }

    Team team = teams[teamIndex];

    Console.WriteLine("1 - Add Developer, 2 - Add Manager, 3 - Info, 4 - Detailed Info, 5 - Add Team, 0 - Exit");
    string choice = Console.ReadLine();

    if (choice == "0")
    {
        break;
    }

    if (choice == "1")
    {
        Console.Write("Developer name: ");
        string name = Console.ReadLine();
        team.AddWorker(new Developer(name));
    }
    else if (choice == "2")
    {
        Console.Write("Manager name: ");
        string name = Console.ReadLine();
        team.AddWorker(new Manager(name));
    }
    else if (choice == "3")
    {
        team.PrintInfo();
    }
    else if (choice == "4")
    {
        team.PrintDetailedInfo();
    }
    else if (choice == "5")
    {
        Console.Write("Enter team name: ");
        string newTeamName = Console.ReadLine();
        teams.Add(new Team(newTeamName));
    }
}

public abstract class Worker
{
    public string Name
    {
        get;
        set;
    }
    public string Position
    {
        get;
        set;
    }
    public string WorkDay
    {
        get;
        set;
    }

    public Worker(string name)
    {
        Name = name;
        WorkDay = "";
    }

    public void Call()
    {
        WorkDay += "Call ";
    }

    public void WriteCode()
    {
        WorkDay += "WriteCode ";
    }

    public void Relax()
    {
        WorkDay += "Relax ";
    }

    public abstract void FillWorkDay();
}

public class Developer : Worker
{
    public Developer(string name) : base(name)
    {
        Position = "Developer";
    }

    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}

public class Manager : Worker
{
    private Random random;

    public Manager(string name) : base(name)
    {
        Position = "Manager";
        random = new Random();
    }

    public override void FillWorkDay()
    {
        int firstCalls = random.Next(1, 11);
        for (int i = 0; i < firstCalls; i++)
        {
            Call();
        }

        Relax();

        int secondCalls = random.Next(1, 6);
        for (int i = 0; i < secondCalls; i++)
        {
            Call();
        }
    }
}

public class Team
{
    public string Name
    {
        get;
        set;
    }
    private List<Worker> workers;

    public Team(string name)
    {
        Name = name;
        workers = new List<Worker>();
    }

    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }

    public void PrintInfo()
    {
        Console.WriteLine(Name);
        foreach (var worker in workers)
        {
            Console.WriteLine(worker.Name);
        }
    }

    public void PrintDetailedInfo()
    {
        Console.WriteLine(Name);
        foreach (var worker in workers)
        {
            worker.WorkDay = "";
            worker.FillWorkDay();
            Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay}");
        }
    }
}