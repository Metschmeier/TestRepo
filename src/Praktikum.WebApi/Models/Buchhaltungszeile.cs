namespace Praktikum.WebApi.Models;

public class Buchhaltungszeile
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public string Beschreibung { get; set; } = "";
    public decimal Betrag { get; set; }
}