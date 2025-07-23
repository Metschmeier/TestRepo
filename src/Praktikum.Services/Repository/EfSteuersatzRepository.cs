using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Praktikum.Services.Repository;

public class EfSteuersatzRepository : ISteuersatzRepository
{
    private readonly BuchhaltungDbContext _context;

    public EfSteuersatzRepository(BuchhaltungDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Steuersatzzeile> GetAll()
        => _context.Steuersaetze.AsNoTracking().ToList();

    public Steuersatzzeile? GetById(int id)
    => _context.Steuersaetze.AsNoTracking().FirstOrDefault(b => b.SteuersatzzeileId == id);

    public void Add(Steuersatzzeile zeile)
    {
        _context.Steuersaetze.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Steuersatzzeile zeile)
    {
        var existing = _context.Steuersaetze.Find(id);
        if (existing is null) return false;

        existing.SteuersatzInProzent = zeile.SteuersatzInProzent;
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