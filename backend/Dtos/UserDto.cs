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
