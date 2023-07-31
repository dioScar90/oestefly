namespace backend.Entities;

public class Flight
{
    public int Id { get; set; }
    public string Airline { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public decimal Price { get; set; }
    // Add more properties as needed, e.g., seat availability, class, etc.
}
