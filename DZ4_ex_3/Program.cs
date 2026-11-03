using System;

River river = new River { X = 45.2, Y = 10.5, Name = "Amazon", Description = "Longest river", FlowSpeed = 150, TotalLength = 6992 };
Mountain mountain = new Mountain { X = 27.9, Y = 86.9, Name = "Everest", Description = "Highest mountain", HighestPoint = 8848 };

river.GetInfo();
Console.WriteLine();
mountain.GetInfo();

public abstract class GeographicObject
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

    public virtual void GetInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Coordinates: X={X}, Y={Y}");
        Console.WriteLine($"Description: {Description}");
    }
}

public class River : GeographicObject
{
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

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Flow Speed: {FlowSpeed} cm/s");
        Console.WriteLine($"Total Length: {TotalLength}");
    }
}

public class Mountain : GeographicObject
{
    public double HighestPoint 
    { 
        get; 
        set; 
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Highest Point: {HighestPoint}");
    }
}