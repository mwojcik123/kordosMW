using System;

public class Rental
{
    public Customer Customer { get; set; }
    public Movie Movie { get; set; }
    public DateTime RentalDate { get; set; }

    public Rental(Customer customer, Movie movie)
    {
        Customer = customer;
        Movie = movie;
        RentalDate = DateTime.Now;
    }
}
