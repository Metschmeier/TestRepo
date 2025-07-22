using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Praktikum.Services.Repository;

public class EfSteuersatzRepository : ISteuersatzRepository
{
    private readonly SteuersatzDbContext _context;

    public EfSteuersatzRepository(SteuersatzDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Steuersatzzeile> GetAll()
        => _context.Steuersatz.AsNoTracking().ToList();

    public Steuersatzzeile? GetById(int id)
    => _context.Steuersatz.AsNoTracking().FirstOrDefault(b => b.SteuersatzzeileId == id);

    public void Add(Steuersatzzeile zeile)
    {
        _context.Steuersatz.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Steuersatzzeile zeile)
    {
        var existing = _context.Steuersatz.Find(id);

        existing.SteuersatzInProzent = zeile.SteuersatzInProzent;
        existing.Prozentsatz = zeile.Prozentsatz;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _context.Steuersatz.Find(id);
        if (existing is null) return false;

        _context.Steuersatz.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}