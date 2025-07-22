namespace Praktikum.WebApi.Models;
using Praktikum.Types;

public static class KategoriezeileMapper
{
    public static Kategoriezeile ToEntity(this KategoriezeileDto dto)
        => new()
        {
            KategoriezeileId = dto.KategorieId,
            KategorieNummer = dto.KategorieNummer,
            KategorieName = dto.KategorieName,
        };
}
