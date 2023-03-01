using Core.Entities.Interfaces;

namespace Core.Entities;

public class CarModel : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastModified { get; set; }
    public ManufacturerModel Manufacturer { get; set; }
    public short Year { get; set; }
    public string Color { get; set; }
    public SellerModel Seller { get; set; }
}