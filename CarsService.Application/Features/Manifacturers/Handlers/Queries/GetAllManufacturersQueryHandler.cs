using Application.Dtos.Manufacturer;
using Application.Features.Manifacturers.Requests.Queries;
using AutoMapper;
using Core.Persistence;
using MediatR;

namespace Application.Features.Manifacturers.Handlers.Queries;

public class GetAllManufacturersQueryHandler : IRequestHandler<GetAllManufacturersQuery, List<ManufacturerDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public GetAllManufacturersQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ManufacturerDto>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
    {
        var manufacturers = await _unitOfWork.ManufacturerRepository.GetAll();
        if (manufacturers is null)
        {
            throw new Exception("We could not find any manufacturer.");
        }

        var manufacturersDetails = new List<ManufacturerDto>();
        foreach (var manufacturer in manufacturers)
        {
            manufacturersDetails.Add(_mapper.Map<ManufacturerDto>(manufacturer));
        }
        
        return manufacturersDetails;
    }
}