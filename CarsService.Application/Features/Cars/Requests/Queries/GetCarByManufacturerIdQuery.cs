using Core.Entities;
using MediatR;

namespace Application.Features.Cars.Requests.Queries;

public class GetCarByManufacturerIdQuery : IRequest<List<CarViewModel>>
{
    public Guid Id { get; set; }
    public int Pagination { get; set; }
    public int Page { get; set; }
    
}