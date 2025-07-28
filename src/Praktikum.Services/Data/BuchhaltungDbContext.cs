using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Praktikum.Types;

namespace Praktikum.Services.Data;

public class BuchhaltungDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Buchung> Buchungen => Set<Buchung>();
    public DbSet<Partnerzeile> Partner => Set<Partnerzeile>();
    public DbSet<Steuersatzzeile> Steuersaetze => Set<Steuersatzzeile>();
    public DbSet<Kostenstellezeile> Kostenstellen => Set<Kostenstellezeile>();
    public DbSet<Kategoriezeile> Kategorien => Set<Kategoriezeile>();

    public BuchhaltungDbContext(DbContextOptions<BuchhaltungDbContext> options)
        : base(options)
    {
    }
}