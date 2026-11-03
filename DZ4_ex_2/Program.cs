using System;

Converter<decimal> converter = new Converter<decimal>(44.89m, 50.31m);

while (true)
{
    Console.WriteLine("\n1 - UAH to USD, 2 - UAH to EUR, 3 - USD to UAH, 4 - EUR to UAH, 0 - Exit");
    string choice = Console.ReadLine();

    if (choice == "0")
    {
        break;
    }

    if (choice == "1")
    {
        Console.Write("Enter UAH amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine($"Result: {converter.UahToUsd(amount)} USD");
    }
    else if (choice == "2")
    {
        Console.Write("Enter UAH amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine($"Result: {converter.UahToEur(amount)} EUR");
    }
    else if (choice == "3")
    {
        Console.Write("Enter USD amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine($"Result: {converter.UsdToUah(amount)} UAH");
    }
    else if (choice == "4")
    {
        Console.Write("Enter EUR amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine($"Result: {converter.EurToUah(amount)} UAH");
    }
}

public class Converter<T>
{
    public T UsdRate
    {
        get;
        set;
    }
    public T EurRate
    {
        get;
        set;
    }

    public Converter(T usd, T eur)
    {
        UsdRate = usd;
        EurRate = eur;
    }

    public decimal UahToUsd(T amount)
    {
        decimal a = Convert.ToDecimal(amount);
        decimal rate = Convert.ToDecimal(UsdRate);
        return Math.Round(a / rate, 2);
    }

    public decimal UahToEur(T amount)
    {
        decimal a = Convert.ToDecimal(amount);
        decimal rate = Convert.ToDecimal(EurRate);
        return Math.Round(a / rate, 2);
    }

    public decimal UsdToUah(T amount)
    {
        decimal a = Convert.ToDecimal(amount);
        decimal rate = Convert.ToDecimal(UsdRate);
        return Math.Round(a * rate, 2);
    }

    public decimal EurToUah(T amount)
    {
        decimal a = Convert.ToDecimal(amount);
        decimal rate = Convert.ToDecimal(EurRate);
        return Math.Round(a * rate, 2);
    }
}