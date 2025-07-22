namespace Praktikum.WebApi.Models;
using Praktikum.Types;

public static class SteuersatzzeileMapper
{
    public static Steuersatzzeile ToEntity(this SteuersatzzeileDto dto)
        => new()
        {
            SteuersatzzeileId = dto.SteuersatzId,
            SteuersatzInProzent = dto.SteuersatzInProzent,
            Prozentsatz = dto.Prozentsatz,
        };
}