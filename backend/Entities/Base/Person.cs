using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities;

public abstract class Person : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    [NotMapped]
    public string GetFullName => $"{FirstName} {LastName}";
}