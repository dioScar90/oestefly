namespace backend.Dtos;

public record FlightDto (
    int Id,
    string Airline,
    string FlightNumber,
    string DepartureAirport,
    string ArrivalAirport,
    DateTime DepartureDateTime,
    DateTime ArrivalDateTime,
    decimal Price
);
