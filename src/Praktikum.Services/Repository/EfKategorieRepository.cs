using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Praktikum.Types.DTOs;
using AutoMapper.QueryableExtensions;

namespace Praktikum.Services.Repository;

public class EfKategorieRepository : IKategorieRepository
{
    private readonly BuchhaltungDbContext _context;
    private readonly IMapper _mapper;

    public EfKategorieRepository(BuchhaltungDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Kategoriezeile> GetAll()
        => _context.Kategorien.AsNoTracking().ToList();

    public Kategoriezeile? GetById(int id)
    => _context.Kategorien.AsNoTracking().FirstOrDefault(b => b.Id == id);

    public KategorieDto? GetDtoById(int id)
    => _context.Kategorien.Where(b => b.Id == id).ProjectTo<KategorieDto>(_mapper.ConfigurationProvider).AsNoTracking().FirstOrDefault();


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
        existing.Kategorie = zeile.Kategorie;

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