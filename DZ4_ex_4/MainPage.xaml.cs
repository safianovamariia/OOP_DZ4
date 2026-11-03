using System.Collections.ObjectModel;
using System;

namespace DZ4_ex_4;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Product> Products 
    { 
        get; 
        set; 
    }
    private Random random = new Random();

    public MainPage()
    {
        InitializeComponent();

        Products = new ObservableCollection<Product>
        {
            new Grocery { Name = "Onion", Price = 30.5m, Country = "Egypt", PackDate = DateTime.Now, Description = "Fresh onions", ExpirationDate = DateTime.Now.AddDays(25), Quantity = 30, Unit = "kg" },
            new Book { Name = "Shadows of Forgotten Ancestors", Price = 700m, Country = "Ukraine", PackDate = DateTime.Now, Description = "Ukrainian book", PageCount = 200, Publisher = "Stone Publishing", Authors = "Mykhailo Kotsiubynsky" }
        };

        ProductsList.ItemsSource = Products;
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        int r = random.Next(3);
        if (r == 0)
        {
            Products.Add(new Grocery { Name = "Coconut", Price = 60m, Country = "Indonesia", PackDate = DateTime.Now, Description = "Fresh coconuts", ExpirationDate = DateTime.Now.AddDays(20), Quantity = 15, Unit = "kg" });
        }
        else if (r == 1)
        {
            Products.Add(new Book { Name = "Harry Potter", Price = 1000m, Country = "UK", PackDate = DateTime.Now, Description = "Fantasy book", PageCount = 300, Publisher = "Bloomsbury", Authors = "J.K. Rowling" });
        }
        else
        {
            Products.Add(new Grocery { Name = "Juice", Price = 40m, Country = "Brazil", PackDate = DateTime.Now, Description = "Orange juice", ExpirationDate = DateTime.Now.AddDays(60), Quantity = 5, Unit = "L" });
        }
    }

    private void OnRemoveClicked(object sender, EventArgs e)
    {
        if (ProductsList.SelectedItem is Product selected)
        {
            Products.Remove(selected);
        }
        else if (Products.Count > 0)
        {
            Products.RemoveAt(Products.Count - 1);
        }
    }
}

public class Product
{
    public decimal Price 
    {
        get; 
        set; 
    }
    public string Country 
    { 
        get; 
        set; 
    }
    public string Name 
    { 
        get; 
        set; 
    }
    public DateTime PackDate 
    { 
        get; 
        set; 
    }
    public string Description 
    { 
        get; 
        set; 
    }


    public virtual string Details => Description;
}

public class Grocery : Product
{
    public DateTime ExpirationDate 
    { 
        get; 
        set; 
    }
    public int Quantity 
    { 
        get; 
        set; 
    }
    public string Unit 
    { 
        get; 
        set; 
    }

    public override string Details => $"ExpDate: {ExpirationDate:dd.MM.yyyy}, Quantity: {Quantity}{Unit}";
}

public class Book : Product
{
    public int PageCount 
    { 
        get; 
        set; 
    }
    public string Publisher 
    { 
        get; 
        set; 
    }
    public string Authors 
    { 
        get; 
        set; 
    }

    public override string Details => $"Pages: {PageCount}, Pub: {Publisher}, By: {Authors}";
}