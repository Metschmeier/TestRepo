using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Praktikum.Services.Repository;
using Praktikum.Types;
using Praktikum.Services.DTOs;

[ApiController]
[Route("api/[controller]")]
public class KategorieController : ControllerBase
{
    private readonly IKategorieRepository _repo;
    private readonly IMapper _mapper;

    public KategorieController(IKategorieRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Create([FromBody] KategorieDto dto)
    {
        var entity = _mapper.Map<Kategoriezeile>(dto);
        _repo.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.KategoriezeileId }, _mapper.Map<KategorieDto>(entity));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entity = _repo.GetById(id);
        if (entity == null) return NotFound();

        var dto = _mapper.Map<KategorieDto>(entity);
        return Ok(dto);
    }
}
