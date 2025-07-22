namespace Praktikum.WebApi.Models;
using Praktikum.Types;

public static class KostenstellezeileMapper
{
    public static Kostenstellezeile ToEntity(this KostenstellezeileDto dto)
        => new()
        {
            KostenstellezeileId = dto.KostenstelleId,
            KostenstelleOrt = dto.KostenstelleOrt,
            KostenstelleBeschreibung = dto.KostenstelleOrt,
        };
}
