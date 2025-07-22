namespace Praktikum.WebApi.Models;
using Praktikum.Types;

public static class BuchhaltungszeileMapper
{
    public static Buchhaltungszeile ToEntity(this BuchhaltungszeileDto dto)
        => new()
        {
            Id = dto.Id,
            Betrag = dto.Betrag,
            Beschreibung = dto.Beschreibung,
            Datum = dto.Datum,
            Locked = dto.Locked,
        };

    public static Buchhaltungszeile ToEntity(this CreateBuchhaltungszeileDto dto)
       => new()
       {
           Betrag = dto.Betrag,
           Typ = dto.Typ,
           Beschreibung = dto.Beschreibung,
           Datum = dto.Datum,
           Locked = dto.Locked,
       };

    public static BuchhaltungszeileDto ToDto(this Buchhaltungszeile entity)
    => new()
    {
        Id = entity.Id,
        Betrag = entity.Betrag,
        Beschreibung = entity.Beschreibung,
        Datum = entity.Datum,
        Locked = entity.Locked
    };
}