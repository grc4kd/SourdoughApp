using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace webapi.Services
{
    public interface IValuesService
    {
        string Find(int id);
        IEnumerable<string> FindAll();
    }
}
