using Application.Dtos.Manufacturer;
using MediatR;

namespace Application.Features.Manifacturers.Requests.Queries;

public class GetManufacturerByIdQuery : IRequest<ManufacturerDto>
{
    public Guid Id { get; set; }
}