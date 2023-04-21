using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Core.Entities.BaseEntities;

public enum AuditType
{
    None = 0,
    Create = 1,
    Update = 2,
    Delete = 3
}
public class AuditEntry
{
    public AuditEntry()
    {
          
    }

    public string EntityName { get; set; }
    public int AuditId { get; set; }
    public Dictionary<string, object> RowIds { get; } = new();
    public Dictionary<string, object> OldRowValues { get; } = new();
    public Dictionary<string, object> NewRowValues { get; } = new();
    public string UpdatedBy { get; set; }
    public AuditType OperationType { get; set; }
    public List<PropertyEntry> TempProperties { get; set; }

    public AuditModel ToAudit()
    {
        var audit = new AuditModel();
        audit.AuditId = AuditId;
        audit.OperationType = OperationType.ToString();
        audit.Timestamp = DateTime.Now;
        audit.UpdatedBy = UpdatedBy;
        audit.RowsIds = JsonConvert.SerializeObject(RowIds);
        audit.OldRowValues = OldRowValues.Count == 0 ? null : JsonConvert.SerializeObject(OldRowValues);
        audit.NewRowValues = NewRowValues.Count == 0 ? null : JsonConvert.SerializeObject(NewRowValues);
        audit.EntityName = EntityName;

        return audit;
    }
}