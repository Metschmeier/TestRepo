using Microsoft.AspNetCore.Mvc;
using Praktikum.WebApi.Models;
using Praktikum.Services.Repository;
using Praktikum.Types;


namespace Praktikum.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KostenstelleController : ControllerBase
{
    private readonly IKostenstelleRepository _repository;

    public KostenstelleController(IKostenstelleRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Kostenstellezeile>> GetAll()
    => Ok(_repository.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Kostenstellezeile> GetById(int id)
    {
        var z = _repository.GetById(id);
        return z is not null ? Ok(z) : NotFound();
    }

    [HttpPost]
    public ActionResult<Kostenstellezeile> Create(KostenstellezeileDto dto)
    {

        var entity = dto.ToEntity();
        _repository.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.KostenstellezeileId }, entity);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, KostenstellezeileDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing == null)
            return NotFound();

        var entity = dto.ToEntity();
        entity.KostenstellezeileId = id;

        if (!_repository.Update(id, entity))
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_repository.Delete(id)) return NotFound();
        return NoContent();
    }

}