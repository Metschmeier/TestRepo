using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Praktikum.Services.Repository;

public class EfKategorieRepository : IKategorieRepository
{
    private readonly KategorieDbContext _context;

    public EfKategorieRepository(KategorieDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Kategoriezeile> GetAll()
        => _context.Kategorie.AsNoTracking().ToList();

    public Kategoriezeile? GetById(int id)
    => _context.Kategorie.AsNoTracking().FirstOrDefault(b => b.KategoriezeileId == id);

    public void Add(Kategoriezeile zeile)
    {
        _context.Kategorie.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Kategoriezeile zeile)
    {
        var existing = _context.Kategorie.Find(id);

        existing.KategorieNummer = zeile.KategorieNummer;
        existing.KategorieName = zeile.KategorieName;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _context.Kategorie.Find(id);
        if (existing is null) return false;

        _context.Kategorie.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}