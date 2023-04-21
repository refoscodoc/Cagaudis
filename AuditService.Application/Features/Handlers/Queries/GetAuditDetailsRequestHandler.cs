using AuditService.Application.Features.Requests.Queries;
using Core.Entities;
using MediatR;

namespace AuditService.Application.Features.Handlers.Queries;

public class GetAuditDetailsRequestHandler : IRequestHandler<GetAuditDetailsRequest, AuditModel>
{
    public Task<AuditModel> Handle(GetAuditDetailsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}