using Application.Dtos.Cars;
using Application.Features.Requests.Queries;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarsService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CarsController> _logger;

    public CarsController(ILogger<CarsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarModel>>> Get()
    {
        await Task.Delay(2000);
        return Ok("done");
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CarModel>> Get(Guid id)
    {
        var car = await _mediator.Send(new GetCarByIdQuery { Id = id });
        return Ok("done");
    }
    
    [HttpPost]
    public async Task<ActionResult<CarModel>> Post(CarDto model)
    {
        await Task.Delay(2000);
        return Ok("done");
    }
    
    [HttpPut]
    public async Task<ActionResult<CarModel>> Update()
    {
        await Task.Delay(2000);
        return Ok("done");
    }
}