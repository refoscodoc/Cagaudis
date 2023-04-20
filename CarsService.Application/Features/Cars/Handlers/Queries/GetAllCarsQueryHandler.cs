using Application.Dtos.Cars;
using Application.Features.Cars.Requests.Queries;
using AutoMapper;
using Core.Persistence;
using MediatR;

namespace Application.Features.Cars.Handlers.Queries;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<CarDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public GetAllCarsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _unitOfWork.CarRepository.GetAll();
        if (cars is null)
        {
            throw new Exception("We could not find any car.");
        }

        var carsDetails = new List<CarDto>();
        foreach (var car in cars)
        {
            carsDetails.Add(_mapper.Map<CarDto>(car));
        }
        
        return carsDetails;
    }
}