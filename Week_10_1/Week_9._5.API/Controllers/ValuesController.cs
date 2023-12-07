using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Week_10_1.Infrastructure.Services;

namespace DessignPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {

        }
            [HttpGet]
            public void Get(string name)
            {
                ConfigurationService.Instance.GetValue(name);
            }
        }
    }
