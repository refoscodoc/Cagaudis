using Core.Entities.BaseEntities;

namespace Core.Entities;

public class CarModel : BaseEntity
{
    public Guid Id { get; set; }
    public ManufacturerModel Manufacturer { get; set; }
    public short Year { get; set; }
    public string Color { get; set; }
    public SellerModel Seller { get; set; }
}