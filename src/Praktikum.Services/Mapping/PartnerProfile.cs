using AutoMapper;
using Praktikum.Types;
using Praktikum.Services.DTOs;

namespace Praktikum.Services.Mapping;

public class PartnerProfile : Profile
{
    public PartnerProfile()
    {
        CreateMap<Partnerzeile, PartnerDto>().ReverseMap();
    }
}
