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
    public ManufacturerModel Manufacturer { get; set; }
    public SellerModel Seller { get; set; }

    public string Photo { get; set; }
    public DateTime Deadline { get; set; }
    public int priceStart { get; set; }
    public int priceCurrent { get; set; }
    public int Mileage { get; set; }
    public FuelType FuelType { get; set; }
    public bool IsModified { get; set; }
    public int? valueModified { get; set; }
    public AddressModel Address { get; set; }
}