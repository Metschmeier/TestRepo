using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Praktikum.Services.Repository;
using Praktikum.Types;
using Praktikum.Types.DTOs;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BuchhaltungController : ControllerBase
{
    private readonly IBuchhaltungRepository _repo;
    private readonly IMapper _mapper;

    public BuchhaltungController(IBuchhaltungRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Create([FromBody] BuchungDto dto)
    {
        var entity = _mapper.Map<Buchung>(dto);
        _repo.Add(entity);
        return CreatedAtAction(nameof(GetDtoById), new { id = entity.Id }, _mapper.Map<BuchungDto>(entity));
    }

    [HttpGet("{id}")]
    public IActionResult GetDtoById(int id)
    {
        var entity = _repo.GetDtoById(id);
        if (entity == null) return NotFound();

        var dto = _mapper.Map<BuchungDto>(entity);
        return Ok(dto);
    }
}
