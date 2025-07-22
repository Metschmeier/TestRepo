using Microsoft.EntityFrameworkCore;
using Praktikum.Types;

namespace Praktikum.Services.Data;

public class BuchhaltungDbContext : DbContext
{
    public DbSet<Buchhaltungszeile> Buchungen => Set<Buchhaltungszeile>();

    public BuchhaltungDbContext(DbContextOptions<BuchhaltungDbContext> options)
        : base(options)
    {
    }
}
