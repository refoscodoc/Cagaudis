using Application.Dtos.Manufacturer;
using Application.Features.Requests.Commands;
using AutoMapper;
using Core.Entities;
using Core.Persistence;
using MediatR;

namespace Application.Features.Handlers.Commands;

public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, ManufacturerDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CreateManufacturerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<ManufacturerDto> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var response = new ManufacturerDto();

        if (request.CreateManufacturerDto is not null)
        {
            var manufacturer = _mapper.Map<ManufacturerModel>(request.CreateManufacturerDto);
            manufacturer.IsActive = true;
            await _unitOfWork.ManufacturerRepository.Add(manufacturer);
            await _unitOfWork.Save();
        }
        
        return response;
    }
}