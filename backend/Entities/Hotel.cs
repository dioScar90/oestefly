namespace backend.Entities;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public decimal PricePerNight { get; set; }
    public int StarRating { get; set; }
    // Add more properties as needed, e.g., amenities, room types, etc.
}
