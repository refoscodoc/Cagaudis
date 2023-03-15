using Core.Entities;
using Core.Enums;

namespace AuditService.Application.Dtos;

public class CarDto
{
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