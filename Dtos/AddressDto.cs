using oestefly.Entities;

namespace oestefly.Dtos;

public record AddressDto (
    int Id,
    StreetType StreetType,
    string Street,
    string Number,
    string? Complement,
    string Neighborhood,
    string City,
    State State,
    string Country,
    string PostalCode
);