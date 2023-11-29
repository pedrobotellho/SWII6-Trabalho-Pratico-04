using Microsoft.EntityFrameworkCore;
using SWII6_Models.Models;

namespace SWII6_TP03.Context;

public class TpContext : DbContext
{
    public TpContext(DbContextOptions<TpContext> options) : base(options)
    {
    }
    public DbSet<Carro> Carros { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Carro>().HasKey(m => m.Id);

        base.OnModelCreating(builder);
    }
}
