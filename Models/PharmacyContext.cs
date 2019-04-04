using Microsoft.EntityFrameworkCore;

namespace Pharmacy
{
    public class PharmacyContext : DbContext
    {
        public DbSet<Ordered> Ordered { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Indication> Indications{ get; set; }
        public DbSet<Group> Groups { get; set; }

        public PharmacyContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=pharmacyappdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordered>().HasKey(x => new { x.DrugId, x.OrderId });
            modelBuilder.Entity<Indication>().HasKey(x => new { x.DrugId, x.SymptomId });

            modelBuilder.Entity<Drug>();
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<Client>();
            modelBuilder.Entity<Symptom>();
            modelBuilder.Entity<Group>();
        }
    }
}
