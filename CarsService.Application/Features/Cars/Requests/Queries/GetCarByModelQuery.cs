using Core.Entities;
using MediatR;

namespace Application.Features.Cars.Requests.Queries;

public class GetCarByModelQuery : IRequest<List<CarViewModel>>
{
    public string Model { get; set; }
    public int Pagination { get; set; }
    public int Page { get; set; }
}