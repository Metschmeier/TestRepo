using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Praktikum.Services.Repository;

public class EfPartnerRepository : IPartnerRepository
{
    private readonly PartnerDbContext _context;

    public EfPartnerRepository(PartnerDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Partnerzeile> GetAll()
        => _context.Partner.AsNoTracking().ToList();

    public Partnerzeile? GetById(int id)
    => _context.Partner.AsNoTracking().FirstOrDefault(b => b.PartnerzeileId == id);

    public void Add(Partnerzeile zeile)
    {
        _context.Partner.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Partnerzeile zeile)
    {
        var existing = _context.Partner.Find(id);

        existing.Kontonummer = zeile.Kontonummer;
        existing.PartnerName = zeile.PartnerName;
        existing.PartnerTyp = zeile.PartnerTyp;
        existing.Adresse = zeile.Adresse;
        existing.EMail = zeile.EMail;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _context.Partner.Find(id);
        if (existing is null) return false;

        _context.Partner.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}