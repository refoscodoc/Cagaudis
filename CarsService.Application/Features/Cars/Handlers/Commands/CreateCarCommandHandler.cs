using Application.Dtos.Cars;
using Application.Features.Cars.Requests.Commands;
using AutoMapper;
using Core.Entities;
using Core.Persistence;
using Core.Responses;
using MediatR;

namespace Application.Features.Cars.Handlers.Commands;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, BaseCommandResponse<CarModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CreateCarCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseCommandResponse<CarModel>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<CarModel>();
        
        // var validator = new CreateProcessDtoValidator();
        //var validationResult = await validator.ValidateAsync(request.CarDto);
          
        // if (validationResult.IsValid == false)
        // {
        //     throw new ValidationException(validationResult);
        // }
        // else
        // {
        var car = _mapper.Map<CarModel>(request.CreateCarDto);
            car = await _unitOfWork.CarRepository.Add(car);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Request Created Successfully";
            response.Id = car.Id;
        // }
        
        return response;
    }
}