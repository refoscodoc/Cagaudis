using Application.Dtos.Cars;
using Core.Entities;
using Core.Responses;
using MediatR;

namespace Application.Features.Cars.Requests.Commands;

public class CreateCarCommand : IRequest<BaseCommandResponse<CarModel>>
{
    public CarDto CreateCarDto { get; set; }
}