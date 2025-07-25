using Praktikum.Types;
using Praktikum.Services.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Praktikum.Types.DTOs;
using AutoMapper.QueryableExtensions;

namespace Praktikum.Services.Repository;

public class EfPartnerRepository : IPartnerRepository
{
    private readonly BuchhaltungDbContext _context;
    private readonly IMapper _mapper;


    public EfPartnerRepository(BuchhaltungDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Partnerzeile> GetAll()
        => _context.Partner.AsNoTracking().ToList();

    public Partnerzeile? GetById(int id)
    => _context.Partner.AsNoTracking().FirstOrDefault(b => b.Id == id);

    public PartnerDto? GetDtoById(int id)
    => _context.Partner.Where(b => b.Id == id).ProjectTo<PartnerDto>(_mapper.ConfigurationProvider).AsNoTracking().FirstOrDefault();

    public void Add(Partnerzeile zeile)
    {
        _context.Partner.Add(zeile);
        _context.SaveChanges();
    }

    public bool Update(int id, Partnerzeile zeile)
    {
        var existing = _context.Partner.Find(id);
        if (existing is null) return false;

        existing.Kontonummer = zeile.Kontonummer;
        existing.Name = zeile.Name;
        existing.Typ = zeile.Typ;
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