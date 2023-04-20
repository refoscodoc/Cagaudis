using Application.Dtos.Manufacturer;
using MediatR;

namespace Application.Features.Manifacturers.Requests.Queries;

public class GetAllManufacturersQuery  : IRequest<List<ManufacturerDto>>
{
    
}