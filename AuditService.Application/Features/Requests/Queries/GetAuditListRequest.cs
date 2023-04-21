using Core.Entities;
using MediatR;

namespace AuditService.Application.Features.Requests.Queries;

public class GetAuditListRequest : IRequest<List<AuditModel>>
{
    
}