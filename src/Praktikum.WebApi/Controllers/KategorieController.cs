using Microsoft.AspNetCore.Mvc;
using Praktikum.WebApi.Models;
using Praktikum.Services.Repository;
using Praktikum.Types;


namespace Praktikum.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KategorieController : ControllerBase
{
    private readonly IKategorieRepository _repository;

    public KategorieController(IKategorieRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Kategoriezeile>> GetAll()
    => Ok(_repository.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Kategoriezeile> GetById(int id)
    {
        var z = _repository.GetById(id);
        return z is not null ? Ok(z) : NotFound();
    }

    [HttpPost]
    public ActionResult<Kategoriezeile> Create(KategoriezeileDto dto)
    {

        var entity = dto.ToEntity();
        _repository.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.KategoriezeileId }, entity);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, KategoriezeileDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing == null)
            return NotFound();

        var entity = dto.ToEntity();
        entity.KategoriezeileId = id;

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