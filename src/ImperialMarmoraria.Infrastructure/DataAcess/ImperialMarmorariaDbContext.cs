using ImperialMarmoraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImperialMarmoraria.Infrastructure.DataAcess;
internal class ImperialMarmorariaDbContext : DbContext
{
    public ImperialMarmorariaDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<User> Users { get; set; }
}
