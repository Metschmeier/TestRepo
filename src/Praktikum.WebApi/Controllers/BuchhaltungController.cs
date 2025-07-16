using Microsoft.AspNetCore.Mvc;
using Praktikum.WebApi.Models;

namespace Praktikum.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuchhaltungController : ControllerBase
{
    private static readonly List<Buchhaltungszeile> _zeilen = new()
    {
        new Buchhaltungszeile { Id = 1, Datum = new DateTime(2025, 1, 10), Beschreibung = "Büromaterial", Betrag = -45.90m },
        new Buchhaltungszeile { Id = 2, Datum = new DateTime(2025, 1, 12), Beschreibung = "Kundenzahlung", Betrag = 800.00m },
        new Buchhaltungszeile { Id = 3, Datum = new DateTime(2025, 1, 15), Beschreibung = "Fahrtkosten", Betrag = -32.50m }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Buchhaltungszeile>> GetAll()
    {
        return Ok(_zeilen);
    }

    [HttpGet("{id}")]
    public ActionResult<Buchhaltungszeile> GetById(int id)
    {
        var zeile = _zeilen.FirstOrDefault(z => z.Id == id);
        return zeile is not null ? Ok(zeile) : NotFound();
    }
}
