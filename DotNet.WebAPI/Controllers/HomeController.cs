using DotNet.WebAPI.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotNet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        private readonly SchoolSettings _schoolSettings;

        public HomeController(IConfiguration configuration, //SchoolSettings schoolSettings
            IOptions<SchoolSettings> schoolSettings)
        {
            _configuration = configuration;
            _schoolSettings = schoolSettings.Value;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_configuration["UserData:UserName"]);
            
        }
        [HttpGet("GetSchool")]
        public IActionResult GetSchool()
        {
            return Ok(_schoolSettings.SchoolAddress.State);
        }
    }
}
