using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10_1.Application
{
    public interface IConfigurationService
    {
        Task<string> GetValueAsync(string key);
    }
}

