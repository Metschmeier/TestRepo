namespace Praktikum.Types.DTOs
{
    public class PartnerDto
    {
        public int? Id { get; set; }
        public string Kontonummer { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Typ { get; set; } = string.Empty;
        public string Adresse {  get; set; } = string.Empty;
        public string EMail {  get; set; } = string.Empty;
    }
}
