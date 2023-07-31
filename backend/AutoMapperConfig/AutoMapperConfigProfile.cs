using AutoMapper;
using backend.Dtos;
using backend.Entities;

namespace backend.AutoMapperConfig;

public class AutoMapperConfigProfile : Profile
{
    public AutoMapperConfigProfile()
    {
        // Address
        // CreateMap<CreateAddressDto, Address>();
        // CreateMap<Address, GetAddressDto>();

        // User
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();

        // Barber
    }
}