using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Index()
        {
            var values = "Bu Testdir";

            return Ok(values);
        }
    }
}