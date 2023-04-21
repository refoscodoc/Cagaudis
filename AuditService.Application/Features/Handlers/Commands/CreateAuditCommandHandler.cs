using AuditService.Application.Dtos;
using AuditService.Application.Features.Requests.Commands;
using AutoMapper;
using Core.Entities;
using Core.Persistence;
using MediatR;

namespace AuditService.Application.Features.Handlers.Commands;

public class CreateAuditCommandHandler : IRequestHandler<CreateAuditCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAuditCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateAuditCommand request, CancellationToken cancellationToken)
    { 
        foreach(var au in request.Audits)
        {
            await _unitOfWork.AuditServiceRepository.Add(au);
        }
        await _unitOfWork.Save();
        return 1;
    }
}