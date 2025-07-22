using Microsoft.EntityFrameworkCore;
using Praktikum.Types;

namespace Praktikum.Services.Data;

public class KostenstelleDbContext : DbContext
{
    public DbSet<Kostenstellezeile> Kostenstelle => Set<Kostenstellezeile>();

    public KostenstelleDbContext(DbContextOptions<KostenstelleDbContext> options)
        : base(options)
    {
    }
}
