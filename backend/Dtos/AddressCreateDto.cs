using backend.Entities;

namespace backend.Dtos;

public record AddressCreateDto (
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
