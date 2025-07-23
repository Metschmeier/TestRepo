using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Praktikum.Services.Repository;

public class EfKostenstelleRepository : IKostenstelleRepository
{
    private readonly BuchhaltungDbContext _context;

    public EfKostenstelleRepository(BuchhaltungDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Kostenstellezeile> GetAll()
        => _context.Kostenstellen.AsNoTracking().ToList();

    public Kostenstellezeile? GetById(int id)
    => _context.Kostenstellen.AsNoTracking().FirstOrDefault(b => b.KostenstellezeileId == id);

    public void Add(Kostenstellezeile zeile)
    {
        _context.Kostenstellen.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Kostenstellezeile zeile)
    {
        var existing = _context.Kostenstellen.Find(id);
        if (existing is null) return false;

        existing.KostenstelleOrt = zeile.KostenstelleOrt;
        existing.KostenstelleBeschreibung = zeile.KostenstelleBeschreibung;

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