using Microsoft.EntityFrameworkCore;

namespace NaukaMVC.Entities
{
    public class BibliotekaDbContext : DbContext
    {
        public BibliotekaDbContext(DbContextOptions<BibliotekaDbContext> options) : base(options) 
        {

        }

        public DbSet<KsiazkaEntity> Ksiazki{ get; set; }
        public DbSet<RecenzjaEntity> Recenzje { get; set; }

        /* To nie jest najlepsze rozwiazanie/ connection string do appsetting / implemetacja w Program.cs/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=DESKTOP-0FLV9BN\\SQLEXPRESS;Initial Catalog=NaukaMVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        */
    }
}
