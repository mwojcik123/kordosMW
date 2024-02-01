using System;
using System.Collections.Generic;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;
public class RentalStore
{
    private List<Customer> customers;
    private List<Movie> movies;
    private List<Rental> rentals;

    public RentalStore()
    {
        customers = LoadDataFromJson<List<Customer>>("customers.json") ?? new List<Customer>();
        movies = LoadDataFromJson<List<Movie>>("movies.json") ?? new List<Movie>();
        rentals = LoadDataFromJson<List<Rental>>("rentals.json") ?? new List<Rental>();
    }

    public void AddCustomer()
    {
        Console.Write("Podaj imię klienta: ");
        string name = Console.ReadLine();
        Console.Write("Podaj adres klienta: ");
        string address = Console.ReadLine();

        customers.Add(new Customer(name, address));
        Console.WriteLine("Dodano klienta.");
    }

    public void AddMovie()
    {
        Console.Write("Podaj tytuł filmu: ");
        string title = Console.ReadLine();
        Console.Write("Podaj gatunek filmu: ");
        string genre = Console.ReadLine();

        movies.Add(new Movie(title, genre));
        Console.WriteLine("Dodano film.");
    }

    public void RentMovie()
    {
        Console.Write("Podaj imię klienta: ");
        string customerName = Console.ReadLine();
        Console.Write("Podaj tytuł filmu do wypożyczenia: ");
        string movieTitle = Console.ReadLine();

        Customer customer = customers.Find(c => c.Name == customerName);
        Movie movie = movies.Find(m => m.Title == movieTitle);

        if (customer != null && movie != null)
        {
            rentals.Add(new Rental(customer, movie));
            Console.WriteLine($"{customerName} wypożyczył(a) film: {movieTitle}");
        }
        else
        {
            Console.WriteLine("Nie można znaleźć klienta lub filmu.");
        }
    }

    public void DisplayRentals()
    {
        Console.WriteLine("\nAktualne wypożyczenia:");
        foreach (var rental in rentals)
        {
            Console.WriteLine($"Klient: {rental.Customer.Name}, Film: {rental.Movie.Title}, Data wypożyczenia: {rental.RentalDate}");
        }
    }

    public void SaveDataToJson()
    {
        SaveDataToJson("customers.json", customers);
        SaveDataToJson("movies.json", movies);
        SaveDataToJson("rentals.json", rentals);
    }

    private void SaveDataToJson<T>(string fileName, T data)
    {
        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(fileName, jsonData);
    }

    private T LoadDataFromJson<T>(string fileName)
    {
        if (File.Exists(fileName))
        {
            string jsonData = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        return default(T);
    }
}
