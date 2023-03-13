using Application.Dtos.Cars;
using Application.Features.Requests.Commands;
using AutoMapper;
using Core.Entities;
using Core.Persistence;
using GenericPersistence;
using MediatR;

namespace GenericApplication.Features.Handlers.Commands;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CreateCarCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var response = new CarDto();

        if (request.CreateCarDto is not null)
        {
            var car = _mapper.Map<CarModel>(request.CreateCarDto);
            car.IsActive = true;
            await _unitOfWork.CarRepository.Add(car);
            await _unitOfWork.Save();
        }
        
        return response;
    }
}