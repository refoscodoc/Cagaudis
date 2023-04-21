using Application.Features.Cars.Requests.Queries;
using AutoMapper;
using Core.Entities;
using Core.Persistence;
using MediatR;

namespace Application.Features.Cars.Handlers.Queries;

public class GetCarByManufacturerIdQueryHandler : IRequestHandler<GetCarByManufacturerIdQuery, List<CarViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public GetCarByManufacturerIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public Task<List<CarViewModel>> Handle(GetCarByManufacturerIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}