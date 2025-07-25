namespace Praktikum.Types.DTOs
{
    public class SteuersatzDto
    {
        public int? Id { get; set; }
        public string Bezeichnung { get; set; } =string.Empty;
        public decimal Prozentsatz { get; set; }
    }
}
