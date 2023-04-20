
using Application.Dtos.Cars;
using Application.Dtos.Manufacturer;
using AutoMapper;
using Core.Entities;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarModel, CarDto>().ReverseMap();
        CreateMap<ManufacturerModel, ManufacturerDto>().ReverseMap();
    }
}