namespace backend.Entities;

public class Package
{
    public Flight DepartureFlight { get; set; }
    public Flight ReturnFlight { get; set; }
    public Hotel Accommodation { get; set; }
    public decimal TotalPrice { get; set; }
}
