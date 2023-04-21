using Application.Features.Cars.Requests.Queries;
using AutoMapper;
using Core.Entities;
using Core.Persistence;
using MediatR;

namespace Application.Features.Cars.Handlers.Queries;

public class GetCarByModelQueryHandler : IRequestHandler<GetCarByModelQuery, List<CarViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public GetCarByModelQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public Task<List<CarViewModel>> Handle(GetCarByModelQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}