namespace Praktikum.Types;

public class Kategoriezeile
{
    public int Id { get; set; }
    public string KategorieNummer { get; set; } = string.Empty;
    public string Kategorie { get; set; } = string.Empty;

    //public virtual ICollection<Buchung> Buchungen { get; set; }
}