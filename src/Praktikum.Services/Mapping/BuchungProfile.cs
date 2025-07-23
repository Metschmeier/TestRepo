using AutoMapper;
using Praktikum.Types;
using Praktikum.Services.DTOs;

namespace Praktikum.Services.Mapping;

public class BuchungProfile : Profile
{
    public BuchungProfile()
    {
        CreateMap<Buchung, BuchungDto>().ReverseMap();
    }
}
