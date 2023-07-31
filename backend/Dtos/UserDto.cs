using backend.Entities;

namespace backend.Dtos;

public record UserDto (
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    ICollection<AddressDto> Addresses,
    UserRole Role
);

// public class UserDto
// {
//     public int Id { get; set; }
//     public string FirstName { get; set; }
//     public string LastName { get; set; }
//     public string Email { get; set; }
//     public string Phone { get; set; }
//     // public ICollection<GetAddressDto> Addresses { get; set; }
//     public UserRole Role { get; set; }
// }