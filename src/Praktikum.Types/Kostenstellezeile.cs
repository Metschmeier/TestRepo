namespace Praktikum.Types;

public class Kostenstellezeile
{
    public int Id { get; set; }
    public string Kostenstelle { get; set; } = string.Empty;
    public string Beschreibung { get; set; } = string.Empty;

    //public virtual ICollection<Buchung> Buchungen { get; set; }
}