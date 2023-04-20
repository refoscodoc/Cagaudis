using AuditService.Application.Dtos;
using Core.Entities;

namespace AuditService.Application.Profiles;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuditModel, AuditDto>().ReverseMap();
    }
}