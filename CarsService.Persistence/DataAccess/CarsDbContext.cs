using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsService.Persistence.DataAccess;

public class CarsDbContext : DbContext
{
    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options) { }
    
    public DbSet<CarModel> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<CarModel>(entity =>
        // {
        //     entity.Property(e => e.Name)
        //         .IsRequired()
        //         .HasMaxLength(50)
        //         .IsUnicode(false);
        // });
        //
        // modelBuilder.Entity<CarModel>(entity =>
        // {
        //     entity.Property(e => e.Model)
        //         .IsRequired()
        //         .HasMaxLength(25)
        //         .IsUnicode(false);
        //
        //     entity.Property(e => e.CreatedBy)
        //         .IsRequired()
        //         .HasMaxLength(100)
        //         .IsUnicode(false);
        // });
    }
}