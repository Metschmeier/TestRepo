namespace Praktikum.Types;

public class Steuersatzzeile
{
    public int Id { get; set; }
    public string Bezeichnung { get; set; } = string.Empty;
    public decimal Prozentsatz {  get; set; }

    //public virtual ICollection<Buchung> Buchungen { get; set; }
}