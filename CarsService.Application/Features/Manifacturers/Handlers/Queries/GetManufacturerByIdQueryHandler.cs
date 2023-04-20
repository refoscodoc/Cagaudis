using Application.Dtos.Manufacturer;
using Application.Features.Manifacturers.Requests.Queries;
using AutoMapper;
using Core.Persistence;
using MediatR;

namespace Application.Features.Manifacturers.Handlers.Queries;

public class GetManufacturerByIdQueryHandler : IRequestHandler<GetManufacturerByIdQuery, ManufacturerDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public GetManufacturerByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ManufacturerDto> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken)
    {
        var manufacturer = await _unitOfWork.ManufacturerRepository.Get(request.Id);
        if (manufacturer is null)
        {
            throw new Exception("We could not find this car.");
        }

        var manufacturerDetails = _mapper.Map<ManufacturerDto>(manufacturer);
        return manufacturerDetails;
    }
}