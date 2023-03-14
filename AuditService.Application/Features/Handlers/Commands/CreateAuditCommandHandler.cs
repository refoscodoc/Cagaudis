using AuditService.Application.Dtos;
using AuditService.Application.Features.Requests.Commands;
using AutoMapper;
using Core.Entities;
using Core.Persistence;
using MediatR;

namespace AuditService.Application.Features.Handlers.Commands;

public class CreateAuditCommandHandler : IRequestHandler<CreateAuditCommand, AuditDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAuditCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AuditDto> Handle(CreateAuditCommand request, CancellationToken cancellationToken)
    {
        var response = new AuditDto();

        if (request.Audit is not null)
        {
            var audit = _mapper.Map<AuditModel>(request.Audit);
            audit.IsActive = true;
            await _unitOfWork.AuditServiceRepository.Add(audit);
            await _unitOfWork.Save();
        }
        
        return response;
    }
}