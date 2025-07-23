using AutoMapper;
using Praktikum.Types;
using Praktikum.Services.DTOs;

namespace Praktikum.Services.Mapping;

public class SteuersatzProfile : Profile
{
    public SteuersatzProfile()
    {
        CreateMap<Steuersatzzeile, SteuersatzDto>().ReverseMap();
    }
}
