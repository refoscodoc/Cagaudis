using Core.Entities.Interfaces;

namespace Core.Entities;

public class SellerModel : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastModified { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public LocationModel SellerAddress { get; set; }
}