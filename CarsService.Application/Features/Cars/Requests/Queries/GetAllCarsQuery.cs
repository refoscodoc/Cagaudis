using Application.Dtos.Cars;
using MediatR;

namespace Application.Features.Cars.Requests.Queries;

public class GetAllCarsQuery  : IRequest<List<CarDto>>
{
    
}