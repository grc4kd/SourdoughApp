using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarterMixController : ControllerBase
    {
        private static readonly string[] Statuses = new[]
        {
            "Stasis", "Inactive", "Active", "Mature", "Spoiled", "Alcoholic"
        };

        private readonly ILogger<StarterMixController> _logger;

        public StarterMixController(ILogger<StarterMixController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<StarterMix> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new StarterMix
            {
                Water = rng.Next(1, 100),
                Flour = rng.Next(1, 100),
                Volume = 200,
                TemperatureC = rng.Next(-20, 55),
                Status = Statuses[rng.Next(Statuses.Length)]
            })
            .ToArray();
        }
    }
}
