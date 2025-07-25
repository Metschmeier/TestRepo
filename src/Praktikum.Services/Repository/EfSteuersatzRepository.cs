using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Praktikum.Types.DTOs;
using AutoMapper.QueryableExtensions;

namespace Praktikum.Services.Repository;

public class EfSteuersatzRepository : ISteuersatzRepository
{
    private readonly BuchhaltungDbContext _context;
    private readonly IMapper _mapper;

    public EfSteuersatzRepository(BuchhaltungDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Steuersatzzeile> GetAll()
        => _context.Steuersaetze.AsNoTracking().ToList();

    public Steuersatzzeile? GetById(int id)
    => _context.Steuersaetze.AsNoTracking().FirstOrDefault(b => b.Id == id);

    public SteuersatzDto? GetDtoById(int id)
    => _context.Steuersaetze.Where(b => b.Id == id).ProjectTo<SteuersatzDto>(_mapper.ConfigurationProvider).AsNoTracking().FirstOrDefault();

    public void Add(Steuersatzzeile zeile)
    {
        _context.Steuersaetze.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Steuersatzzeile zeile)
    {
        var existing = _context.Steuersaetze.Find(id);
        if (existing is null) return false;

        existing.Bezeichnung = zeile.Bezeichnung;
        existing.Prozentsatz = zeile.Prozentsatz;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _context.Steuersaetze.Find(id);
        if (existing is null) return false;

        _context.Steuersaetze.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}