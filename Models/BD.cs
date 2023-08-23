using Acesv.Models;
using Acesvv.Areas.Identity.Data;
using Acesvv.Models;
using Microsoft.EntityFrameworkCore;

namespace Acesv2.Models
{
    public class BD : DbContext
    {
        public DbSet<Dados> Dados { get; set; }
        public DbSet<Escola> Escolas { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)       
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-3QU9K7J\SQLEXPRESS; Initial Catalog=Dados;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dados>()
        .Property(d => d.EscolaId)
        .HasColumnName("Escolas")
        .HasConversion(
            v => string.Join(",", v),
            v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList()
        );

        }
    }
}
