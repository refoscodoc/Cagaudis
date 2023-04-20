using Application.Dtos.Manufacturer;
using MediatR;

namespace Application.Features.Manifacturers.Requests.Commands;

public class CreateManufacturerCommand : IRequest<ManufacturerDto>
{
    public ManufacturerDto CreateManufacturerDto { get; set; }
}