using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Praktikum.Services.DTOs;
using AutoMapper.QueryableExtensions;

namespace Praktikum.Services.Repository;

public class EfBuchhaltungRepository : IBuchhaltungRepository
{
    private readonly BuchhaltungDbContext _context;
    private readonly IMapper _mapper;

    public EfBuchhaltungRepository(BuchhaltungDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Buchung> GetAll()
        => _context.Buchungen.AsNoTracking().ToList();

    public Buchung? GetById(int id)
        => _context.Buchungen.AsNoTracking().FirstOrDefault(b => b.Id == id);

    public BuchungDto? GetDtoById(int id)
        => _context.Buchungen.Where(b => b.Id == id).ProjectTo<BuchungDto>(_mapper.ConfigurationProvider).AsNoTracking().FirstOrDefault();

    public void Add(Buchung zeile)
    {
        _context.Buchungen.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Buchung zeile)
    {
        var existing = _context.Buchungen.Find(id);
        if (existing is null || existing.Locked) return false;

        existing.Datum = zeile.Datum;
        existing.Typ = zeile.Typ;
        existing.Beschreibung = zeile.Beschreibung;
        existing.Betrag = zeile.Betrag;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _context.Buchungen.Find(id);
        if (existing is null) return false;

        _context.Buchungen.Remove(existing);
        _context.SaveChanges();
        return true;
    }

    public bool SetLocked(int id, bool locked)
    {
        var existing = _context.Buchungen.Find(id);
        if (existing is null) return false;

        existing.Locked = locked;
        _context.SaveChanges();
        return true;
    }
}