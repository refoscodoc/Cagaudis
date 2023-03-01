using Application.Dtos.Manufacturer;
using Application.Dtos.Seller;

namespace Application.Dtos.Cars;

public class CarDto
{
    public ManufacturerDto Manufacturer { get; set; }
    public short Year { get; set; }
    public string Color { get; set; }
    public SellerDto Seller { get; set; }
}