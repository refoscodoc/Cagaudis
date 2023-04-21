using Core.Contracts;
using Core.DataAccess;
using Core.Entities;
using Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Persistence.DataAccess;

public class AuditableDbContext : GenericDbContext
{
    private readonly IAuditServices _auditServices;

        private List<AuditEntry> _auditEntries;
        public AuditableDbContext(DbContextOptions<GenericDbContext> options, IAuditServices auditServices) : base(options)
        {
            _auditServices = auditServices;
        }

        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.LastModifiedOn = DateTime.Now;
                entry.Entity.LastModifiedBy = username;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = username;
                }
            }

            _auditEntries = OnBeforeSaveChanges(username);
            var result = await base.SaveChangesAsync();
            await OnAfterSaveChangesAsync(_auditEntries);
            return result;
        }

        private List<AuditEntry> OnBeforeSaveChanges(string username)
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditModel || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                {
                    continue;
                }
                var auditEntry = new AuditEntry();
                auditEntry.UpdatedBy = username;
                auditEntry.EntityName = entry.Metadata.ClrType.Name;
                auditEntry.TempProperties = entry.Properties.Where(p => p.IsTemporary).ToList();
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.RowIds[propertyName] = property.CurrentValue;
                        continue;
                    }
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.OperationType = AuditType.Create;
                            auditEntry.NewRowValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.OperationType = AuditType.Delete;
                            auditEntry.NewRowValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OperationType = AuditType.Update;
                                auditEntry.OldRowValues[propertyName] = property.OriginalValue;
                                auditEntry.NewRowValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            return auditEntries;
        }

        private async Task OnAfterSaveChangesAsync(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
            {
                return;
            }

            // For each temporary property in each audit entry - update the value in the audit entry to the actual (generated) value
            foreach (var entry in auditEntries)
            {
                foreach (var prop in entry.TempProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        entry.RowIds[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }
            }

            List<AuditModel> audits = new List<AuditModel>();
            foreach (var auditEntry in auditEntries)
            {
                audits.Add(auditEntry.ToAudit());
            }
            await _auditServices.AddAudits(audits);
        }
}