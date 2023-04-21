using Application.Dtos.Cars;
using Core.Entities;
using MediatR;

namespace Application.Features.Cars.Requests.Queries;

public class GetCarByIdQuery : IRequest<CarViewModel>
{
    public Guid Id { get; set; }
}