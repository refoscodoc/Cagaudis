using Application.Dtos.Cars;
using Core.Entities;
using MediatR;

namespace Application.Features.Cars.Requests.Queries;

public class GetAllCarsQuery  : IRequest<List<CarViewModel>>
{
    public int Pagination { get; set; }
}