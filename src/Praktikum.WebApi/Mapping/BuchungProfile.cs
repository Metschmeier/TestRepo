using AutoMapper;
using Praktikum.Types;
using Praktikum.WebApi.DTOs;

namespace Praktikum.WebApi.Mapping;

public class BuchungProfile : Profile
{
    public BuchungProfile()
    {
        CreateMap<Buchung, BuchungDto>().ReverseMap();
    }
}
