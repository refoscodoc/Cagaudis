using AuditService.Application.Dtos;
using AuditService.Application.Features.Requests.Commands;
using AuditService.Application.Features.Requests.Queries;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuditService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuditServiceController : ControllerBase
{
    private readonly ILogger<AuditServiceController> _logger;
    private readonly IMediator _mediator;
    public AuditServiceController(ILogger<AuditServiceController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuditModel>>> Get()
    {
        var audits = await _mediator.Send(new GetAuditListRequest());
        return Ok(audits);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuditModel>> Get(int id)
    {
        var audit = await _mediator.Send(new GetAuditDetailsRequest {  MainAuditId = id });
        return Ok(audit);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] List<AuditModel> audits)
    {
        var result = await _mediator.Send(new CreateAuditCommand { Audits = audits });
        return Ok(result);
    }
}