namespace Praktikum.Types.DTOs;

public class BuchungDto
{
    public int? Id { get; set; }
    public DateTime Datum { get; set; }
    public string Typ { get; set; } = string.Empty;
    public decimal BetragNetto { get; set; }
    public int SteuersatzId { get; set; }
    public SteuersatzDto Steuersatz { get; set; }
    public int PartnerId { get; set; }
    public PartnerDto Partner { get; set; }
    public string Beschreibung { get; set; } = string.Empty;
}