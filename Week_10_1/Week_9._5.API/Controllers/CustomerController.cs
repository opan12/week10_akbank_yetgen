
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_10_1.Application;
using Week_10_1.Infrastructure.Services;
namespace Week_9._5.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {

        }

        [HttpGet]

        [HttpGet]
        public IActionResult Get(string name)
        {
            var value = ConfigurationService.Instance.GetValue(name);
            return Ok(value);
        }
    }
}