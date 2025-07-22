namespace Praktikum.WebApi.Models;
using Praktikum.Types;

public static class PartnerzeileMapper
{
    public static Partnerzeile ToEntity(this PartnerzeileDto dto)
        => new()
        {
            Kontonummer = dto.Kontonummer,
            PartnerName = dto.PartnerName,
            PartnerTyp = dto.PartnerTyp,
            Adresse = dto.Adresse,
            EMail = dto.EMail,
        };
}
