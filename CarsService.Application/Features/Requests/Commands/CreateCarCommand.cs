using Application.Dtos.Cars;
using MediatR;

namespace Application.Features.Requests.Commands;

public class CreateCarCommand : IRequest<CarDto>
{
    public CarDto CreateCarDto { get; set; }
}