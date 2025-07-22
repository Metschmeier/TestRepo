using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Praktikum.Services.Repository;

public class EfKostenstelleRepository : IKostenstelleRepository
{
    private readonly KostenstelleDbContext _context;

    public EfKostenstelleRepository(KostenstelleDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Kostenstellezeile> GetAll()
        => _context.Kostenstelle.AsNoTracking().ToList();

    public Kostenstellezeile? GetById(int id)
    => _context.Kostenstelle.AsNoTracking().FirstOrDefault(b => b.KostenstellezeileId == id);

    public void Add(Kostenstellezeile zeile)
    {
        _context.Kostenstelle.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Kostenstellezeile zeile)
    {
        var existing = _context.Kostenstelle.Find(id);

        existing.KostenstelleOrt = zeile.KostenstelleOrt;
        existing.KostenstelleBeschreibung = zeile.KostenstelleBeschreibung;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _context.Kostenstelle.Find(id);
        if (existing is null) return false;

        _context.Kostenstelle.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}