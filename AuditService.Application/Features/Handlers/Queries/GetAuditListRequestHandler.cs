using AuditService.Application.Features.Requests.Queries;
using AutoMapper;
using Core.Entities;
using Core.Persistence;
using MediatR;

namespace AuditService.Application.Features.Handlers.Queries;

public class GetAuditListRequestHandler : IRequestHandler<GetAuditListRequest, List<AuditModel>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAuditListRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<AuditModel>> Handle(GetAuditListRequest request, CancellationToken cancellationToken)
    {
        var audits = await _unitOfWork.AuditServiceRepository.GetAll();
        return audits;
    }
}