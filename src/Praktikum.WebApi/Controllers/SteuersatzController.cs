using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Praktikum.Services.Repository;
using Praktikum.Types;
using Praktikum.Services.DTOs;

[ApiController]
[Route("api/[controller]")]
public class SteuersatzController : ControllerBase
{
    private readonly ISteuersatzRepository _repo;
    private readonly IMapper _mapper;

    public SteuersatzController(ISteuersatzRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Create([FromBody] SteuersatzDto dto)
    {
        var entity = _mapper.Map<Steuersatzzeile>(dto);
        _repo.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.SteuersatzzeileId }, _mapper.Map<SteuersatzDto>(entity));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entity = _repo.GetById(id);
        if (entity == null) return NotFound();

        var dto = _mapper.Map<SteuersatzDto>(entity);
        return Ok(dto);
    }
}
