using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Praktikum.Services.Repository;

public class EfBuchhaltungRepository : IBuchhaltungRepository
{
    private readonly BuchhaltungDbContext _context;

    public EfBuchhaltungRepository(BuchhaltungDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Buchhaltungszeile> GetAll()
        => _context.Buchungen.AsNoTracking().ToList();

    public Buchhaltungszeile? GetById(int id)
        => _context.Buchungen.AsNoTracking().FirstOrDefault(b => b.Id == id);

    public void Add(Buchhaltungszeile zeile)
    {
        _context.Buchungen.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Buchhaltungszeile zeile)
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