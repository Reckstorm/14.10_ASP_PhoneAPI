using Microsoft.EntityFrameworkCore;

namespace _14._10_ASP.Models
{
    public class PhonesContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Characteristics> Characteristicss { get; set; }
        public PhonesContext(DbContextOptions<PhonesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasOne(x => x.Manufacturer).WithMany().OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(x => x.Characteristics).WithMany().OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
