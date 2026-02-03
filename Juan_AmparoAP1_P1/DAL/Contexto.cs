using Juan_AmparoAP1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Juan_AmparoAP1_P1.DAL;
public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<ViajesEspaciales> ViajesEspaciales { get; set; }
}