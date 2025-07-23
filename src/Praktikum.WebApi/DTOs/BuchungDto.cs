namespace Praktikum.WebApi.DTOs;

public class BuchungDto
{
    public DateTime Datum { get; set; }
    public string Typ { get; set; } = string.Empty;
    public decimal BetragNetto { get; set; }
    public int SteuersatzId { get; set; }
    public int GegenkontoId { get; set; }
    public string Beschreibung { get; set; } = string.Empty;
}