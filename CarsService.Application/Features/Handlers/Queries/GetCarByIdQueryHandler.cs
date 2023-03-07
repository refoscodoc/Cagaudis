using Application.Dtos.Cars;
using Application.Features.Requests.Queries;
using AutoMapper;
using Core.Persistence;
using GenericPersistence;
using MediatR;

namespace GenericApplication.Features.Handlers.Queries;

public class GetCarQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public GetCarQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _unitOfWork.CarRepository.Get(request.Id);
        if (car is null)
        {
            throw new Exception("We could not find this car.");
        }

        var carDetails = _mapper.Map<CarDto>(car);
        return carDetails;
    }
}