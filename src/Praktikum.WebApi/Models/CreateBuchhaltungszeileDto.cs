namespace Praktikum.WebApi.Models;

public class CreateBuchhaltungszeileDto
{
    public DateTime Datum { get; set; }
    public string Typ { get; set; } = string.Empty;
    public string Beschreibung { get; set; } = string.Empty;
    public decimal Betrag { get; set; }
    public bool Locked { get; set; } = false;
}
