using AutoMapper;
using Praktikum.Types;
using Praktikum.Services.DTOs;

namespace Praktikum.Services.Mapping;

public class KategorieProfile : Profile
{
    public KategorieProfile()
    {
        CreateMap<Kategoriezeile, KategorieDto>().ReverseMap();
    }
}
