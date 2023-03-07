using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Persistence.DataAccess;

public class AuditableDbContext : DbContext
{
    public AuditableDbContext(DbContextOptions<AuditableDbContext> options) : base(options) { }
    
    public DbSet<Audit> Cars { get; set; }

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