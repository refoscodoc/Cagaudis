using System.ComponentModel.DataAnnotations;
using Core.Entities.BaseEntities;

namespace Core.Entities;

public class SellerViewModel : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid SellerAddress { get; set; }
}