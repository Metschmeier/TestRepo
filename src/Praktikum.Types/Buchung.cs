namespace Praktikum.Types;

public class Buchung
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public string Typ { get; set; } = string.Empty;
    public string Beschreibung { get; set; } = string.Empty;
    public decimal BetragNetto { get; set; }
    //public bool Locked { get; set; } = false;

    public int SteuersatzId { get; set; }
    public virtual Steuersatzzeile Steuersatz { get; set; }

    public int PartnerId { get; set; }
    public virtual Partnerzeile Partner { get; set; }

    public int KostenstelleId { get; set; }
    public virtual Kostenstellezeile Kostenstelle { get; set; }

    public int KategorieId { get; set; }
    public virtual Kategoriezeile Kategorie { get; set; }
}