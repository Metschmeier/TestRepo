using Microsoft.EntityFrameworkCore;
using Praktikum.Types;

namespace Praktikum.Services.Data;

public class KategorieDbContext : DbContext
{
    public DbSet<Kategoriezeile> Kategorie => Set<Kategoriezeile>();

    public KategorieDbContext(DbContextOptions<KategorieDbContext> options)
        : base(options)
    {
    }
}
