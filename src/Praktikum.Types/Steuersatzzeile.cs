namespace Praktikum.Types;

public class Steuersatzzeile
{
    public int SteuersatzzeileId { get; set; }
    public string SteuersatzInProzent { get; set; } = string.Empty;
    public int Prozentsatz {  get; set; }

    //public virtual ICollection<Buchung> Buchungen { get; set; }
}