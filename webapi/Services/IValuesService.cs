using System.Collections;
using System.Collections.Generic;

namespace webapi.Services
{
    public interface IValuesService
    {
        IEnumerable<string> FindAll();
        string Find(int id);
    }
}
