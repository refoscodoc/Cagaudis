using System.ComponentModel.DataAnnotations;
using Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

public class AddressModel : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public String Street;
    public int PostalCode;
    public String City;
}