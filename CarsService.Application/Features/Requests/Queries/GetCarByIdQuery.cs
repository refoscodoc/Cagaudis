using Application.Dtos.Cars;
using MediatR;

namespace Application.Features.Requests.Queries;

public class GetCarByIdQuery : IRequest<CarDto>
{
    public Guid Id { get; set; }
}