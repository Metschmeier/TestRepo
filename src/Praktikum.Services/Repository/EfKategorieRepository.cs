using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Praktikum.Services.Repository;

public class EfKategorieRepository : IKategorieRepository
{
    private readonly BuchhaltungDbContext _context;

    public EfKategorieRepository(BuchhaltungDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Kategoriezeile> GetAll()
        => _context.Kategorien.AsNoTracking().ToList();

    public Kategoriezeile? GetById(int id)
    => _context.Kategorien.AsNoTracking().FirstOrDefault(b => b.KategoriezeileId == id);

    public void Add(Kategoriezeile zeile)
    {
        _context.Kategorien.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Kategoriezeile zeile)
    {
        var existing = _context.Kategorien.Find(id);
        if (existing is null) return false;


        existing.KategorieNummer = zeile.KategorieNummer;
        existing.KategorieName = zeile.KategorieName;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _context.Kategorien.Find(id);
        if (existing is null) return false;

        _context.Kategorien.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}