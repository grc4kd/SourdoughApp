using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService _valuesService;

        public ValuesController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _valuesService.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id) 
        {
            return _valuesService.Find(id);
        }
    }
}
