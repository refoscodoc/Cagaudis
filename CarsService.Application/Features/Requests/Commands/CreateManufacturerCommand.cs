using Application.Dtos.Cars;
using Application.Dtos.Manufacturer;
using MediatR;

namespace Application.Features.Requests.Commands;

public class CreateManufacturerCommand : IRequest<ManufacturerDto>
{
    public ManufacturerDto CreateManufacturerDto { get; set; }
}