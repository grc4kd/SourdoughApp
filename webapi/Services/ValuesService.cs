using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace webapi.Services
{
    public class ValuesService : IValuesService
    {
        private readonly ILogger<ValuesService> _logger;

        public ValuesService(ILogger<ValuesService> logger)
        {
            _logger = logger;
        }

        public string Find(int id)
        {
            _logger.LogDebug("{method} called with {id}", nameof(this.Find), id);

            return $"value{id}";
        }

        public IEnumerable<string> FindAll()
        {
            _logger.LogDebug("{method} called", nameof(this.FindAll));

            return new[] { "value1", "value2" };
        }
    }
}
