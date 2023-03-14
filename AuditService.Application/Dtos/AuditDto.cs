namespace AuditService.Application.Dtos;

public class AuditDto
{
    public Guid Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastModified { get; set; }
    public Guid ItemId { get; set; }
    public bool IsActive { get; set; }
}