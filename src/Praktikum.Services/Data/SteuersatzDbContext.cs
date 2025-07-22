using Microsoft.EntityFrameworkCore;
using Praktikum.Types;

namespace Praktikum.Services.Data;

public class SteuersatzDbContext : DbContext
{
    public DbSet<Steuersatzzeile> Steuersatz => Set<Steuersatzzeile>();

    public SteuersatzDbContext(DbContextOptions<SteuersatzDbContext> options)
        : base(options)
    {
    }
}
