using Core.Entities.BaseEntities;

namespace Core.Entities;

public class ManufacturerModel : BaseEntity
{
    public Guid Id { get; set; }
    public string ManufacturerName { get; set; }
    public double Popularity { get; set; }
}