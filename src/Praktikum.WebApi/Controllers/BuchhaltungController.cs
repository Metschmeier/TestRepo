using Microsoft.AspNetCore.Mvc;
using Praktikum.WebApi.Models;
using Praktikum.Services.Repository;
using Praktikum.Types;

namespace Praktikum.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuchhaltungController : ControllerBase
{
    private readonly IBuchhaltungRepository _repository;

    public BuchhaltungController(IBuchhaltungRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Buchhaltungszeile>> GetAll()
        => Ok(_repository.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Buchhaltungszeile> GetById(int id)
    {
        var z = _repository.GetById(id);
        return z is not null ? Ok(z) : NotFound();
    }

    [HttpPost]
    public ActionResult<Buchhaltungszeile> Create(CreateBuchhaltungszeileDto dto)
    {

        var entity = dto.ToEntity();
        _repository.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, BuchhaltungszeileDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing == null)
            return NotFound();

        if (existing.Locked)
            return Conflict("Diese Buchungszeile ist gesperrt und kann nicht geändert werden.");

        var entity = dto.ToEntity();
        entity.Id = id; // ID fixieren

        if (!_repository.Update(id, entity))
            return NotFound();

        return NoContent();
    }

    [HttpPut("lock/{id}")]
    public IActionResult SetLock(int id, [FromQuery] bool locked)
    {
        var entity = _repository.GetById(id);
        if (entity == null)
            return NotFound();

        entity.Locked = locked;

        if (!_repository.Update(id, entity))
            return StatusCode(500, "Lock-Status konnte nicht gesetzt werden.");

        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_repository.Delete(id)) return NotFound();
        return NoContent();
    }
}