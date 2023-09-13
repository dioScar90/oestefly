namespace backend.Entities;

public class User : Person
{
    public string Password { get; set; }
    public UserRole Role { get; set; }
    // public Barber? Barber { get; set; }
    
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}