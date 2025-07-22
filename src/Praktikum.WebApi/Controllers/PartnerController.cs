using Microsoft.AspNetCore.Mvc;
using Praktikum.WebApi.Models;
using Praktikum.Services.Repository;
using Praktikum.Types;


namespace Praktikum.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartnerController : ControllerBase
{
    private readonly IPartnerRepository _repository;

    public PartnerController(IPartnerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Partnerzeile>> GetAll()
    => Ok(_repository.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Partnerzeile> GetById(int id)
    {
        var z = _repository.GetById(id);
        return z is not null ? Ok(z) : NotFound();
    }

    [HttpPost]
    public ActionResult<Partnerzeile> Create(PartnerzeileDto dto)
    {

        var entity = dto.ToEntity();
        _repository.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.PartnerzeileId }, entity);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, PartnerzeileDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing == null)
            return NotFound();

        var entity = dto.ToEntity();
        entity.PartnerzeileId = id;

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