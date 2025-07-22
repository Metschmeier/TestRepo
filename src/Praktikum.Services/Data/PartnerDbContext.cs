using Microsoft.EntityFrameworkCore;
using Praktikum.Types;

namespace Praktikum.Services.Data;

public class PartnerDbContext : DbContext
{
    public DbSet<Partnerzeile> Partner => Set<Partnerzeile>();

    public PartnerDbContext(DbContextOptions<PartnerDbContext> options)
        : base(options)
    { 
    }
}
