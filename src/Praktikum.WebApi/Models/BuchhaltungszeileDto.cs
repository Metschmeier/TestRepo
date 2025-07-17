namespace Praktikum.WebApi.Models;

public class BuchhaltungszeileDto
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public string Beschreibung { get; set; } = string.Empty;
    public decimal Betrag { get; set; }
    public bool Locked { get; set; } = false;
}
