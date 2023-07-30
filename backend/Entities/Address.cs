using oestefly.Entities;

namespace oestefly.Entities;

public class Address : BaseEntity
{
    public int Id { get; set; }
    public StreetType StreetType { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string? Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public State State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; } = "Brasil";
    
    public int UserId { get; set; }
    public User User { get; set; }
}
