using api.models;
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
        public IEnumerable<SourdoughStarterMix> Get()
        {
            var rng = new Random();
            _logger.LogDebug("Seeded random number generator {rng}", rng);

            

            return Enumerable.Range(1, 100).Select(index => new SourdoughStarterMix
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
