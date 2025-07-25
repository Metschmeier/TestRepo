using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Praktikum.Types.DTOs;
using AutoMapper.QueryableExtensions;

namespace Praktikum.Services.Repository;

public class EfKostenstelleRepository : IKostenstelleRepository
{
    private readonly BuchhaltungDbContext _context;
    private readonly IMapper _mapper;

    public EfKostenstelleRepository(BuchhaltungDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Kostenstellezeile> GetAll()
        => _context.Kostenstellen.AsNoTracking().ToList();

    public Kostenstellezeile? GetById(int id)
    => _context.Kostenstellen.AsNoTracking().FirstOrDefault(b => b.Id == id);

    public KategorieDto? GetDtoById(int id)
    => _context.Kostenstellen.Where(b => b.Id == id).ProjectTo<KategorieDto>(_mapper.ConfigurationProvider).AsNoTracking().FirstOrDefault();


    public void Add(Kostenstellezeile zeile)
    {
        _context.Kostenstellen.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Kostenstellezeile zeile)
    {
        var existing = _context.Kostenstellen.Find(id);
        if (existing is null) return false;

        existing.Kostenstelle = zeile.Kostenstelle;
        existing.Beschreibung = zeile.Beschreibung;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _context.Kostenstellen.Find(id);
        if (existing is null) return false;

        _context.Kostenstellen.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}