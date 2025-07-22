namespace Praktikum.WebApi.Models;

public class KostenstellezeileDto
{
    public int KostenstelleId { get; set; }
    public string KostenstelleOrt { get; set; } = string.Empty;
    public string KostenstelleBeschreibung {  get; set; } = string.Empty;
}
