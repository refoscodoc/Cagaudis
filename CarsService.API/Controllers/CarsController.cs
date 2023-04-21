using Application.Dtos.Cars;
using Application.Features.Cars.Requests.Commands;
using Application.Features.Cars.Requests.Queries;
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
    public async Task<ActionResult<IEnumerable<CarViewModel>>> Get(int pagination)
    {
        var cars = await _mediator.Send(new GetAllCarsQuery { Pagination = pagination });
        return Ok(cars);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CarViewModel>> Get(Guid id)
    {
        var car = await _mediator.Send(new GetCarByIdQuery { Id = id });
        return Ok(car);
    }
    
    [HttpPost]
    public async Task<ActionResult<CarModel>> Post(CarDto car)
    {
        var result = await _mediator.Send(new CreateCarCommand { CreateCarDto = car });
        return Ok("done");
    }
    
    [HttpPut]
    public async Task<ActionResult<CarModel>> Update()
    {
        await Task.Delay(2000);
        return Ok("done");
    }
}