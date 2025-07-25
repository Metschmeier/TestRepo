using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Praktikum.Services.Repository;
using Praktikum.Types;
using Praktikum.Types.DTOs;

[ApiController]
[Route("api/[controller]")]
public class KostenstelleController : ControllerBase
{
    private readonly IKostenstelleRepository _repo;
    private readonly IMapper _mapper;

    public KostenstelleController(IKostenstelleRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Create([FromBody] KostenstelleDto dto)
    {
        var entity = _mapper.Map<Kostenstellezeile>(dto);
        _repo.Add(entity);
        return CreatedAtAction(nameof(GetDtoById), new { id = entity.Id }, _mapper.Map<KostenstelleDto>(entity));
    }

    [HttpGet("{id}")]
    public IActionResult GetDtoById(int id)
    {
        var entity = _repo.GetDtoById(id);
        if (entity == null) return NotFound();

        var dto = _mapper.Map<KostenstelleDto>(entity);
        return Ok(dto);
    }
}
