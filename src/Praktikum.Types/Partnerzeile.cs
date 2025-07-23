namespace Praktikum.Types;

    public class Partnerzeile
    {
        public int PartnerzeileId { get; set; }
        public string Kontonummer { get; set; } = string.Empty;
        public string PartnerName { get; set; } = string.Empty;
        public string PartnerTyp { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;

        //public virtual ICollection<Buchung> Buchungen { get; set; }
}
