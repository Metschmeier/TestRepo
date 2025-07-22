namespace Praktikum.WebApi.Models;

public class SteuersatzzeileDto
{
    public int SteuersatzId { get; set; }
    public string SteuersatzInProzent { get; set; } = string.Empty;
    public int Prozentsatz {  get; set; }
}
