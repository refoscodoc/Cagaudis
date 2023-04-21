using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class AuditModel
{
    [Key]
    public int AuditId { get; set; }
    public string RowsIds { get; set; }
    public string EntityName { get; set; }
    public string NewRowValues { get; set; }
    public string OldRowValues { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime Timestamp { get; set; }
    public string OperationType { get; set; }
}