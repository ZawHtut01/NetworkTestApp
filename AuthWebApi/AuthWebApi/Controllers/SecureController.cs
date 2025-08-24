using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecureController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "This is a secure endpoint!" });
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok(new { Message = "This is an admin-only endpoint!" });
        }
    }
}
