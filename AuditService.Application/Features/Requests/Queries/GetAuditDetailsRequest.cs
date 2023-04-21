using Core.Entities;
using MediatR;

namespace AuditService.Application.Features.Requests.Queries;

public class GetAuditDetailsRequest : IRequest<AuditModel>
{
    public int MainAuditId { get; set; }
}