namespace Praktikum.Types;

public class Kostenstellezeile
{
    public int KostenstellezeileId { get; set; }
    public string KostenstelleOrt { get; set; } = string.Empty;
    public string KostenstelleBeschreibung { get; set; } = string.Empty;

    //public virtual ICollection<Buchung> Buchungen { get; set; }
}