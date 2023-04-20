using System.ComponentModel.DataAnnotations;
using Core.Entities.BaseEntities;
using Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Core.Entities;

public class CarModel : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public short Year { get; set; }
    public string Color { get; set; }
    public Guid ManufacturerId { get; set; }
    public Guid SellerId { get; set; }

    public string Photo { get; set; }
    public DateTime Deadline { get; set; }
    public int PriceStart { get; set; }
    public int PriceCurrent { get; set; }
    public int Mileage { get; set; }
    public FuelType FuelType { get; set; }
    public bool IsModified { get; set; }
    public int? ValueModified { get; set; }
    public Guid AddressId { get; set; }
}