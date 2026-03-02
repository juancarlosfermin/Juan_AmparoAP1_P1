using Juan_AmparoAP1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Juan_AmparoAP1_P1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
        public DbSet<TiposHuacales> TiposHuacales { get; set; }
        public DbSet<EntradasHuacalesDetalle> EntradasHuacalesDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EntradasHuacales>().ToTable("EntradassHuacales");

            modelBuilder.Entity<TiposHuacales>().HasData(
                new TiposHuacales { TipoId = 1, Descripcion = "Huacales Rojos", Existencia = 0 },
                new TiposHuacales { TipoId = 2, Descripcion = "Huacales Verdes", Existencia = 0 }
            );
        }
    }
}