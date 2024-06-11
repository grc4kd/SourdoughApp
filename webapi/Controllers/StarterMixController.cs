using webapi.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace webapi.Controllers
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
        public IEnumerable<Starter> Get()
        {
            var rng = new Random();
            _logger.LogDebug("Seeded random number generator {rng}", rng);

            return Enumerable.Range(1, 100)
                .Select(index => new Starter(rng.Next(1, 100), rng.Next(1, 100)))
                .ToArray();
        }
    }
}
