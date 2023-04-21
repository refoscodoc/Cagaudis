using Core.Entities;
using MediatR;

namespace Application.Features.Cars.Requests.Queries;

public class GetCarByModelQuery : IRequest<List<CarViewModel>>
{
    public string Model { get; set; }
}