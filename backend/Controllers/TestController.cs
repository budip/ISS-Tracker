using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(new { message = "Hello from Test Controller!" });
        }
    }
}