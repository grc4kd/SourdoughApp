using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class StarterMixController : ControllerBase
{
    private readonly ILogger<StarterMixController> _logger;

    public StarterMixController(ILogger<StarterMixController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetStarterMix")]
    public IEnumerable<StarterMix> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new StarterMix
        {
            Flour = 100,
            Water = 100
        })
        .ToArray();
    }
}
