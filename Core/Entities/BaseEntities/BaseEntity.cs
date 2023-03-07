namespace Core.Entities.BaseEntities;

public class BaseEntity
{
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public bool IsActive { get; set; }
}