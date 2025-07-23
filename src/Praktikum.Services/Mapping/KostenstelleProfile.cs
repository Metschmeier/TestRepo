using AutoMapper;
using Praktikum.Types;
using Praktikum.Services.DTOs;

namespace Praktikum.Services.Mapping;

public class KostenstelleProfile : Profile
{
    public KostenstelleProfile()
    {
        CreateMap<Kostenstellezeile, KostenstelleDto>().ReverseMap();
    }
}
