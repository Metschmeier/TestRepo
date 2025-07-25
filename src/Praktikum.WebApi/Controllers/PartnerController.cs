using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Praktikum.Services.Repository;
using Praktikum.Types;
using Praktikum.Types.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PartnerController : ControllerBase
{
    private readonly IPartnerRepository _repo;
    private readonly IMapper _mapper;

    public PartnerController(IPartnerRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Create([FromBody] PartnerDto dto)
    {
        var entity = _mapper.Map<Partnerzeile>(dto);
        _repo.Add(entity);
        return CreatedAtAction(nameof(GetDtoById), new { id = entity.Id }, _mapper.Map<PartnerDto>(entity));
    }

    [HttpGet("{id}")]
    public IActionResult GetDtoById(int id)
    {
        var entity = _repo.GetDtoById(id);
        if (entity == null) return NotFound();

        var dto = _mapper.Map<PartnerDto>(entity);
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] PartnerDto dto)
    {
        var entity = _mapper.Map<Partnerzeile>(dto);
        bool updated = _repo.Update(id, entity);

        if (!updated) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _repo.Delete(id);

        if (!deleted) return NotFound();

        return NoContent();
    }
}
