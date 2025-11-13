using Microsoft.EntityFrameworkCore;
using Sistema_de_Personagens.Models;

namespace Sistema_de_Personagens.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Personagem> TabelaPersonagem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>()
            .HasDiscriminator<string>("Tipo")
            .HasValue<Mago>("Mago")
            .HasValue<Guerreiro>("Guerreiro");
        }
    }
}