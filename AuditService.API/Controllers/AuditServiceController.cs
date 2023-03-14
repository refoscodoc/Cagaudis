using AuditService.Application.Features.Requests.Commands;
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

    [HttpPost]
    public async Task<ActionResult<AuditModel>> Get(SellerModel seller, CarModel car)
    {
        var audit = await _mediator.Send(new CreateAuditCommand
        {
            Audit = new AuditModel
            {
                Id = Guid.NewGuid(),
                CreatedBy = seller.Username, // TODO add user
                DateCreated = DateTime.Today,
                LastModified = DateTime.Now,
                ItemId = car.Id
            }
        });
        return Ok(audit);
    }
}