using Core.Entities.Interfaces;

namespace Core.Entities;

public class ManufacturerModel : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastModified { get; set; }
    public string ManufacturerName { get; set; }
}