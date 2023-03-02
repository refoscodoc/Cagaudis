using Core.Entities.BaseEntities;

namespace Core.Entities;

public class ManufacturerModel : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastModified { get; set; }
    public string ManufacturerName { get; set; }
}