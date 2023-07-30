using AutoMapper;
using oestefly.Dtos;
using oestefly.Entities;

namespace oestefly.AutoMapperConfig;

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