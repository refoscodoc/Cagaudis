using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess;

public class GenericDbContext : DbContext
{
    public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options) { }
    
    public DbSet<AuditModel> Audits { get; set; }
    public DbSet<CarModel> Cars { get; set; }
    public DbSet<SellerModel> Sellers { get; set; }
    public DbSet<ManufacturerModel> Manufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarModel>(entity =>
        {
            entity.Property(e => e.Seller)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ManufacturerModel>(entity =>
        {
            entity.Property(e => e.ManufacturerName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });
    }
    
}