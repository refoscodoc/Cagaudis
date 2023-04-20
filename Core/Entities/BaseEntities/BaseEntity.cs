namespace Core.Entities.BaseEntities;

public class BaseEntity
{
    public DateTime DateCreated { get; set; } = DateTime.Today;
    public string CreatedBy { get; set; } = "DEFAULT_USER";
    public DateTime CreatedOn { get; set; } = DateTime.Today;
    public DateTime LastModifiedOn { get; set; } = DateTime.Today;
    public string LastModifiedBy { get; set; } = "DEFAULT_USER";
    public bool IsActive { get; set; } = true;
}