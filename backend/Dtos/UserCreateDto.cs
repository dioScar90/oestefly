using backend.Entities;

namespace backend.Dtos;

public record UserCreateDto (
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    ICollection<AddressCreateDto> Addresses,
    UserRole Role
);
