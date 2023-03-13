using Microsoft.AspNetCore.Mvc;

namespace AuditService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuditServiceController : ControllerBase
{
    private readonly ILogger<AuditServiceController> _logger;

    public AuditServiceController(ILogger<AuditServiceController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<AuditModel> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}