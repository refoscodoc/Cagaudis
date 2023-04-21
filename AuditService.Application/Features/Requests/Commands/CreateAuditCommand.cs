using AuditService.Application.Dtos;
using Core.Entities;
using MediatR;

namespace AuditService.Application.Features.Requests.Commands;

public class CreateAuditCommand : IRequest<int>
{
    public List<AuditModel> Audits { get; set; }
}