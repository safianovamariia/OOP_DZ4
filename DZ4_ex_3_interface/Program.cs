using System;

River river = new River { X = 45.2, Y = 10.5, Name = "Nile", Description = "Long river", FlowSpeed = 120, TotalLength = 6650 };
Mountain mountain = new Mountain { X = 27.9, Y = 86.9, Name = "K2", Description = "Second highest mountain", HighestPoint = 8611 };

river.GetInfo();
Console.WriteLine();
mountain.GetInfo();

public interface IGeographicObject
{
    double X 
    { 
        get; 
        set; 
    }
    double Y 
    { 
        get;
        set; 
    }
    string Name 
    { 
        get; 
        set; 
    }
    string Description 
    { 
        get; 
        set; 
    }

    void GetInfo();
}

public class River : IGeographicObject
{
    public double X 
    { 
        get; 
        set; 
    }
    public double Y 
    { 
        get; 
        set; 
    }
    public string Name 
    { 
        get; 
        set; 
    }
    public string Description 
    { 
        get; 
        set; 
    }
    public double FlowSpeed 
    { 
        get; 
        set; 
    }
    public double TotalLength 
    { 
        get;
        set; 
    }

    public void GetInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Coordinates: X={X}, Y={Y}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Flow Speed: {FlowSpeed} cm/s");
        Console.WriteLine($"Total Length: {TotalLength}");
    }
}

public class Mountain : IGeographicObject
{
    public double X 
    { 
        get; 
        set; 
    }
    public double Y 
    { 
        get; 
        set; 
    }
    public string Name 
    { 
        get; 
        set; 
    }
    public string Description 
    { 
        get; 
        set; 
    }
    public double HighestPoint 
    { 
        get; 
        set; 
    }

    public void GetInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Coordinates: X={X}, Y={Y}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Highest Point: {HighestPoint}");
    }
}