using Core.Entities.BaseEntities;

namespace Core.Entities;

public class SellerModel : BaseEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual LocationModel SellerAddress { get; set; }
}