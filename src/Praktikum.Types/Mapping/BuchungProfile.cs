using AutoMapper;
using Praktikum.Types.DTOs;

namespace Praktikum.Types.Mapping;

public class BuchungProfile : Profile
{
    public BuchungProfile()
    {
        CreateMap<Buchung, BuchungDto>().ReverseMap();
        CreateMap<Kategoriezeile, KategorieDto>().ReverseMap();
        CreateMap<Kostenstellezeile, KostenstelleDto>().ReverseMap();
        CreateMap<Partnerzeile, PartnerDto>().ReverseMap();
        CreateMap<Steuersatzzeile, SteuersatzDto>().ReverseMap();
    }
}
