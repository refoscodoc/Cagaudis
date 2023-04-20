using Core.Entities;

namespace AuditService.Application.Dtos;

public class SellerDto
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual LocationModel SellerAddress { get; set; }
}