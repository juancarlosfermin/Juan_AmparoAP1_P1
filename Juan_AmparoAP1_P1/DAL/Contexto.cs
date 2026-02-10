using Juan_AmparoAP1_P1.Models;
using Juan_AmparoAP1_P1.Services;
using Microsoft.EntityFrameworkCore;

namespace Juan_AmparoAP1_P1.DAL;
public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EntradasHuacales>().ToTable("EntradassHuacales");
    }

}








