using Application.Dtos.Manufacturer;
using Application.Features.Manifacturers.Requests.Commands;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarsService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ManufacturerController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ManufacturerController> _logger;

    public ManufacturerController(ILogger<ManufacturerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ManufacturerModel>>> Get()
    {
        await Task.Delay(2000);
        return Ok("done");
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ManufacturerModel>> Get(Guid id)
    {
        await Task.Delay(2000);
        return Ok("done");
    }
    
    [HttpPost]
    public async Task<ActionResult<ManufacturerModel>> Post(ManufacturerDto manufacturer) 
    {
        var result = await _mediator.Send(new CreateManufacturerCommand { CreateManufacturerDto = manufacturer });
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<ManufacturerModel>> Update()
    {
        await Task.Delay(2000);
        return Ok("done");
    }
}