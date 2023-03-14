using AuditService.Application.Dtos;
using Core.Entities;
using MediatR;

namespace AuditService.Application.Features.Requests.Commands;

public class CreateAuditCommand : IRequest<AuditDto>
{
    public AuditModel Audit { get; set; }
}